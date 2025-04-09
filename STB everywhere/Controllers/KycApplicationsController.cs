// Controllers/KycApplicationsController.cs
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
            .Include(k => k.ApplicantDetails)
            .Include(k => k.Addresses)
            .Include(k => k.AddressProofs)
            .Include(k => k.Documents)
            .Include(k => k.Signature)
            .FirstOrDefaultAsync(k => k.Id == id);

        if (kycApplication == null)
        {
            return NotFound();
        }

        return _mapper.Map<KycApplicationDto>(kycApplication);
    }

    // Add other endpoints as needed (GET all, PUT, DELETE, etc.)
}