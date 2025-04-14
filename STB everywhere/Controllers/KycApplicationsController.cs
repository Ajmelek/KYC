using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;

[ApiController]
[Route("api/[controller]")]
public class KycApplicationsController : ControllerBase
{
    private readonly KycDbContext _context;
    private readonly IMapper _mapper;

    public KycApplicationsController(KycDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<KycApplicationDto>> CreateKycApplication(KycApplicationDto kycApplicationDto)
    {
        var kycApplication = _mapper.Map<KycApplication>(kycApplicationDto);

        _context.KycApplications.Add(kycApplication);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetKycApplication),
            new { id = kycApplication.Id },
            _mapper.Map<KycApplicationDto>(kycApplication));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<KycApplicationDto>> GetKycApplication(int id)
    {
        var kycApplication = await _context.KycApplications
            .FirstOrDefaultAsync(k => k.Id == id);  // Removed unnecessary Include() statements

        if (kycApplication == null)
        {
            return NotFound();
        }

        return _mapper.Map<KycApplicationDto>(kycApplication);  // Mapping the result to the KycApplicationDto
    }

    // Add other endpoints as needed (GET all, PUT, DELETE, etc.)
}
