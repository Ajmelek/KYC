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
    /// Controller for managing admin operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AdminController : ControllerBase
    {
        private readonly KycDbContext _context;
        private readonly AuthService _authService;

        public AdminController(KycDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        /// <summary>
        /// Gets the first admin from the database
        /// </summary>
        [HttpGet("First")]
        [ProducesResponseType(typeof(Admin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Admin>> GetFirstAdmin()
        {
            var admin = await _context.Admins.FirstOrDefaultAsync();

            if (admin == null)
            {
                return NotFound("No admins found in the database");
            }

            return admin;
        }

        /// <summary>
        /// Gets an admin by their ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Admin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == id);

            if (admin == null)
            {
                return NotFound($"Admin with ID {id} not found in the database");
            }

            return admin;
        }

        /// <summary>
        /// Gets an admin by their login
        /// </summary>
        [HttpGet("byLogin/{login}")]
        [ProducesResponseType(typeof(Admin), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Admin>> GetAdminByLogin(string login)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Login == login);

            if (admin == null)
            {
                return NotFound($"Admin with login {login} not found in the database");
            }

            return admin;
        }

        /// <summary>
        /// Gets an admin's ID by their login
        /// </summary>
        [HttpGet("GetIdByLogin/{login}")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> GetAdminIdByLogin(string login)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Login == login);

            if (admin == null)
            {
                return NotFound($"No admin found with login {login}");
            }

            return admin.Id;
        }

        /// <summary>
        /// Authenticates an admin and returns a JWT token
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

            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Login == request.Username);

            if (admin == null)
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            // Check if the password needs to be upgraded to hashed version
            if (admin.Password == request.Password)
            {
                // This is an old plain-text password - upgrade it to hashed version
                admin.Password = _authService.HashPassword(request.Password);
                await _context.SaveChangesAsync();
            }
            else if (!_authService.VerifyPasswordHash(request.Password, admin.Password))
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

            string token = _authService.CreateToken(admin);
            
            return Ok(new LoginResponse { Message = "Login successful", Token = token });
        }
    }
}