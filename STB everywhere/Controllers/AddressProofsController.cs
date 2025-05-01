// Controllers/AddressProofsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;
using STB_everywhere.Dtos;
using STB_everywhere.Models;

[ApiController]
[Route("api/[controller]")]
public class AddressProofsController : ControllerBase
{
    private readonly KycDbContext _context;

    public AddressProofsController(KycDbContext context)
    {
        _context = context;
    }

    [HttpPost("{kycApplicationId}")]
    public async Task<ActionResult<AddressProof>> AddAddressProof(
        int kycApplicationId,
        [FromBody] AddressProofDto proofDto)
    {
        var kycApplication = await _context.KycApplications.FindAsync(kycApplicationId);
        if (kycApplication == null)
        {
            return NotFound("KYC application not found");
        }

        var proof = new AddressProof
        {
            KycApplicationId = kycApplicationId,
            ProofType = proofDto.ProofType,
            IsCorrespondenceAddress = proofDto.IsCorrespondenceAddress
        };

        _context.AddressProofs.Add(proof);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetAddressProofs),
            new { id = proof.Id },
            proof);
    }

    [HttpGet("{kycApplicationId}")]
    public async Task<ActionResult<IEnumerable<AddressProofDto>>> GetAddressProofs(int kycApplicationId)
    {
        var proofs = await _context.AddressProofs
            .Where(p => p.KycApplicationId == kycApplicationId)
            .Select(p => new AddressProofDto
            {
                ProofType = p.ProofType,
                IsCorrespondenceAddress = p.IsCorrespondenceAddress
            })
            .ToListAsync();

        return Ok(proofs);
    }
    
}