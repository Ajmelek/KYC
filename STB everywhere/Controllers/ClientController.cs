using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;
using STB_everywhere.Models;
using System.Linq;
using System.Threading.Tasks;

namespace STB_everywhere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly KycDbContext _context;

        public ClientController(KycDbContext context)
        {
            _context = context;
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
    }
}