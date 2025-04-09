// Controllers/SignaturesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STB_everywhere.Data;
using STB_everywhere.Dtos;
using STB_everywhere.Models;
using System.Text.RegularExpressions;

[ApiController]
[Route("api/[controller]")]
public class SignaturesController : ControllerBase
{
    private readonly KycDbContext _context;
    private readonly ILogger<SignaturesController> _logger;

    public SignaturesController(
        KycDbContext context,
        ILogger<SignaturesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("{kycApplicationId}")]
    public async Task<ActionResult<SignatureResponseDto>> SaveSignature(
        int kycApplicationId,
        [FromBody] SignatureDto signatureDto)
    {
        try
        {
            // Validate KYC application exists
            var kycApplication = await _context.KycApplications.FindAsync(kycApplicationId);
            if (kycApplication == null)
            {
                return NotFound("KYC application not found");
            }

            // Validate signature data
            if (string.IsNullOrWhiteSpace(signatureDto.SignatureData))
            {
                return BadRequest("Signature data is required");
            }

            // Basic validation for Base64 string
            if (!IsValidBase64(signatureDto.SignatureData))
            {
                return BadRequest("Invalid signature format. Must be valid Base64.");
            }

            // Check for existing signature
            var existingSignature = await _context.Signatures
                .FirstOrDefaultAsync(s => s.KycApplicationId == kycApplicationId);

            if (existingSignature != null)
            {
                // Update existing signature
                existingSignature.SignatureData = signatureDto.SignatureData;
                existingSignature.SignatureDate = signatureDto.SignatureDate;
            }
            else
            {
                // Create new signature
                var signature = new Signature
                {
                    KycApplicationId = kycApplicationId,
                    SignatureData = signatureDto.SignatureData,
                    SignatureDate = signatureDto.SignatureDate
                };

                _context.Signatures.Add(signature);
            }

            await _context.SaveChangesAsync();

            return Ok(new SignatureResponseDto
            {
                Success = true,
                SignatureDate = signatureDto.SignatureDate,
                Message = "Signature saved successfully"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving signature for KYC application {KycApplicationId}", kycApplicationId);
            return StatusCode(500, "An error occurred while saving the signature");
        }
    }

    [HttpGet("{kycApplicationId}")]
    public async Task<ActionResult<SignatureDto>> GetSignature(int kycApplicationId)
    {
        var signature = await _context.Signatures
            .FirstOrDefaultAsync(s => s.KycApplicationId == kycApplicationId);

        if (signature == null)
        {
            return NotFound("No signature found for this KYC application");
        }

        return Ok(new SignatureDto
        {
            SignatureData = signature.SignatureData,
            SignatureDate = signature.SignatureDate
        });
    }

    private bool IsValidBase64(string base64String)
    {
        // Basic Base64 validation
        if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
            || !Regex.IsMatch(base64String, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None))
        {
            return false;
        }

        try
        {
            Convert.FromBase64String(base64String);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

// Additional DTO for response
public class SignatureResponseDto
{
    public bool Success { get; set; }
    public DateTime SignatureDate { get; set; }
    public string Message { get; set; }
}