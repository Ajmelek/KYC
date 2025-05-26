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
        [Route("api/[controller]")]
        [ApiController]
        public class ClientController : ControllerBase
        {
            private readonly KycDbContext _context;
            private readonly AuthService _authService;

            public ClientController(KycDbContext context, AuthService authService)
            {
                _context = context;
                _authService = authService;
            }

            // GET: api/Client/First
            [HttpGet("First")]
            public async Task<ActionResult<Client>> GetFirstClient()
            {
                var client = await _context.Clients.FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("No clients found in the database");
                }

                return client;
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Client>> GetClientById(int id)
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);

                if (client == null)
                {
                    return NotFound($"Client with ID {id} not found in the database");
                }

                return client;
            }
            [HttpGet("byLogin/{login}")]
            public async Task<ActionResult<Client>> GetClientByLogin(string login)
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Login == login);

                if (client == null)
                {
                    return NotFound($"Client with login {login} not found in the database");
                }

                return client;
            }

            [HttpGet("GetIdByLogin/{login}")]
            public async Task<ActionResult<long>> GetClientIdByLogin(string login)
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Login == login);

                if (client == null)
                {
                    return NotFound($"No client found with login {login}");
                }

                return client.Id;
            }





            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterRequest request)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Message = "Invalid input" });
                }

                if (await _context.Clients.AnyAsync(c => c.Login == request.Email))
                {
                    return BadRequest(new { Message = "User already exists" });
                }

                var client = new Client
                {
                    Login = request.Email,
                    Nom = request.Nom,
                    Prenom = request.Prenom,
                    Password = _authService.HashPassword(request.Password)
                };

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                string token = _authService.CreateToken(client);

                return Ok(new { Message = "Registration successful", Token = token });
            }

                [HttpPost("login")]
                public async Task<IActionResult> Login([FromBody] LoginRequest request)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(new { Message = "Invalid input" });
                    }

                    var client = await _context.Clients
                        .FirstOrDefaultAsync(c => c.Login == request.Username);

                    if (client == null)
                    {
                        return Unauthorized(new { Message = "Invalid email or password" });
                    }

                    // Check if the password needs to be upgraded to hashed version
                    if (client.Password == request.Password)
                    {
                        // This is an old plain-text password - upgrade it to hashed version
                        client.Password = _authService.HashPassword(request.Password);
                        await _context.SaveChangesAsync();
                    }
                    else if (!_authService.VerifyPasswordHash(request.Password, client.Password))
                    {
                        return Unauthorized(new { Message = "Invalid email or password" });
                    }

                    string token = _authService.CreateToken(client);
            
                    return Ok(new { Message = "Login successful", Token = token });
                }

            }
        }