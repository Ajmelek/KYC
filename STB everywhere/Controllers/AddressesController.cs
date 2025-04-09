// Controllers/AddressesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;
using STB_everywhere.Dtos;
using STB_everywhere.Models;

[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly KycDbContext _context;

    public AddressesController(KycDbContext context)
    {
        _context = context;
    }

    [HttpPost("{kycApplicationId}")]
    public async Task<ActionResult<Address>> AddAddress(
        int kycApplicationId,
        [FromBody] AddressDto addressDto)
    {
        var kycApplication = await _context.KycApplications.FindAsync(kycApplicationId);
        if (kycApplication == null)
        {
            return NotFound("KYC application not found");
        }

        // Validate address type
        if (addressDto.AddressType != "Correspondence" && addressDto.AddressType != "Permanent")
        {
            return BadRequest("AddressType must be either 'Correspondence' or 'Permanent'");
        }

        var address = new Address
        {
            KycApplicationId = kycApplicationId,
            AddressType = addressDto.AddressType,
            AddressLine1 = addressDto.AddressLine1,
            AddressLine2 = addressDto.AddressLine2,
            City = addressDto.City,
            State = addressDto.State,
            ZipCode = addressDto.ZipCode,
            Country = addressDto.Country
        };

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
    nameof(GetAddresses),
    new { kycApplicationId = address.KycApplicationId },
    address);
    }

    [HttpGet("{kycApplicationId}")]
    public async Task<ActionResult<IEnumerable<AddressDto>>> GetAddresses(int kycApplicationId)
    {
        var addresses = await _context.Addresses
            .Where(a => a.KycApplicationId == kycApplicationId)
            .Select(a => new AddressDto
            {
                AddressType = a.AddressType,
                AddressLine1 = a.AddressLine1,
                AddressLine2 = a.AddressLine2,
                City = a.City,
                State = a.State,
                ZipCode = a.ZipCode,
                Country = a.Country
            })
            .ToListAsync();

        return Ok(addresses);
    }
}