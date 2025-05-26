using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;
using STB_everywhere.Dots;
using STB_everywhere.Models;
using STB_everywhere.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STB_everywhere.Controllers
{
    /// <summary>
    /// Controller for managing super admin operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SuperAdminController : ControllerBase
    {
        private readonly KycDbContext _context;
        private readonly AuthService _authService;

        public SuperAdminController(KycDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        /// <summary>
        /// Gets the first super admin from the database
        /// </summary>
        [HttpGet("First")]
        [ProducesResponseType(typeof(SuperAdmin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SuperAdmin>> GetFirstSuperAdmin()
        {
            var superAdmin = await _context.SuperAdmins.FirstOrDefaultAsync();

            if (superAdmin == null)
            {
                return NotFound("No super admins found in the database");
            }

            return superAdmin;
        }

        /// <summary>
        /// Gets a super admin by their ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SuperAdmin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SuperAdmin>> GetSuperAdminById(int id)
        {
            var superAdmin = await _context.SuperAdmins.FirstOrDefaultAsync(s => s.Id == id);

            if (superAdmin == null)
            {
                return NotFound($"SuperAdmin with ID {id} not found in the database");
            }

            return superAdmin;
        }

        /// <summary>
        /// Gets a super admin by their login
        /// </summary>
        [HttpGet("byLogin/{login}")]
        [ProducesResponseType(typeof(SuperAdmin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<SuperAdmin>> GetSuperAdminByLogin(string login)
        {
            var superAdmin = await _context.SuperAdmins.FirstOrDefaultAsync(s => s.Login == login);

            if (superAdmin == null)
            {
                return NotFound($"SuperAdmin with login {login} not found in the database");
            }

            return superAdmin;
        }

        /// <summary>
        /// Gets a super admin's ID by their login
        /// </summary>
        [HttpGet("GetIdByLogin/{login}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> GetSuperAdminIdByLogin(string login)
        {
            var superAdmin = await _context.SuperAdmins.FirstOrDefaultAsync(s => s.Login == login);

            if (superAdmin == null)
            {
                return NotFound($"No super admin found with login {login}");
            }

            return superAdmin.Id;
        }

        /// <summary>
        /// Authenticates a super admin and returns a JWT token
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid input" });
            }

            var superAdmin = await _context.SuperAdmins
                .FirstOrDefaultAsync(s => s.Login == request.Username);

            if (superAdmin == null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            // Check if the password needs to be upgraded to hashed version
            if (superAdmin.Password == request.Password)
            {
                // This is an old plain-text password - upgrade it to hashed version
                superAdmin.Password = _authService.HashPassword(request.Password);
                await _context.SaveChangesAsync();
            }
            else if (!_authService.VerifyPasswordHash(request.Password, superAdmin.Password))
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            string token = _authService.CreateToken(superAdmin);
            
            return Ok(new LoginResponse { Message = "Login successful", Token = token });
        }
    }
}