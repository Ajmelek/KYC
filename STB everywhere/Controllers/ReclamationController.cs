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
    public class ReclamationController : ControllerBase
    {
        private readonly KycDbContext _context;

        public ReclamationController(KycDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reclamation>>> GetReclamations()
        {
            return await _context.Reclamations
                .Include(r => r.Client) 
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Reclamation>> PostReclamation([FromBody] ReclamationDto reclamationDto)
        {
            if (reclamationDto == null)
            {
                return BadRequest("Reclamation data is required");
            }

            // Verify client exists
            if (!await _context.Clients.AnyAsync(c => c.Id == reclamationDto.ClientId))
            {
                return BadRequest($"Client with ID {reclamationDto.ClientId} not found");
            }

            // Create new reclamation using raw SQL
            var insertQuery = @"
                INSERT INTO Reclamations (ClientId, Description)
                VALUES (@ClientId, @Description);
                SELECT SCOPE_IDENTITY();";

            var parameters = new[]
            {
                new Microsoft.Data.SqlClient.SqlParameter("@ClientId", reclamationDto.ClientId),
                new Microsoft.Data.SqlClient.SqlParameter("@Description", reclamationDto.Description)
            };

            var newId = await _context.Database.ExecuteSqlRawAsync(insertQuery, parameters);

            // Create response object
            var newReclamation = new Reclamation
            {
                ID = newId,
                ClientId = reclamationDto.ClientId,
                Description = reclamationDto.Description
            };

            return CreatedAtAction(nameof(GetReclamations), new { id = newReclamation.ID }, newReclamation);
        }
    }
}