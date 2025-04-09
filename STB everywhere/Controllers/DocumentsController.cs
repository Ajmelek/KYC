// Controllers/DocumentsController.cs
using Microsoft.AspNetCore.Mvc;
using STB_everywhere.Data;
using STB_everywhere.Dtos;
using STB_everywhere.Models;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly KycDbContext _context;
    private readonly IWebHostEnvironment _env;
    private readonly IContentTypeProvider _contentTypeProvider;

    public DocumentsController(
        KycDbContext context,
        IWebHostEnvironment env,
        IContentTypeProvider contentTypeProvider)
    {
        _context = context;
        _env = env;
        _contentTypeProvider = contentTypeProvider;
    }

    [HttpPost("upload/{kycApplicationId}")]
    public async Task<ActionResult<DocumentDto>> UploadDocument(
        int kycApplicationId,
        IFormFile file,
        [FromQuery] string documentType = null)
    {
        // Validation
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        if (file.Length > 10 * 1024 * 1024) // 10MB limit
            return BadRequest("File size exceeds 10MB limit");

        var kycApplication = await _context.KycApplications.FindAsync(kycApplicationId);
        if (kycApplication == null)
            return NotFound("KYC application not found");

        // Create secure upload directory
        var uploadsPath = Path.Combine(_env.ContentRootPath, "uploads", kycApplicationId.ToString());
        Directory.CreateDirectory(uploadsPath); // No need to check existence

        // Generate secure filename
        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsPath, uniqueFileName);

        // Save file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Create document record
        var document = new Document
        {
            KycApplicationId = kycApplicationId,
            FileName = file.FileName,
            FilePath = filePath,
            DocumentType = documentType,
            UploadDate = DateTime.UtcNow
        };

        _context.Documents.Add(document);
        await _context.SaveChangesAsync();

        // Return DTO with download URL
        return Ok(new DocumentDto
        {
            Id = document.Id,
            FileName = document.FileName,
            DocumentType = document.DocumentType,
            UploadDate = document.UploadDate,
            DownloadUrl = Url.Action("DownloadDocument", new { id = document.Id })
        });
    }

    [HttpGet("download/{id}")]
    public IActionResult DownloadDocument(int id)
    {
        var document = _context.Documents.Find(id);
        if (document == null)
            return NotFound();

        if (!System.IO.File.Exists(document.FilePath))
            return NotFound("File not found on server");

        // Determine content type
        if (!_contentTypeProvider.TryGetContentType(document.FileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        // Return physical file with original filename
        return PhysicalFile(document.FilePath, contentType, document.FileName);
    }

    [HttpGet("kyc/{kycApplicationId}")]
    public ActionResult<IEnumerable<DocumentDto>> GetDocumentsForKyc(int kycApplicationId)
    {
        var documents = _context.Documents
            .Where(d => d.KycApplicationId == kycApplicationId)
            .Select(d => new DocumentDto
            {
                Id = d.Id,
                FileName = d.FileName,
                DocumentType = d.DocumentType,
                UploadDate = d.UploadDate,
                DownloadUrl = Url.Action("DownloadDocument", new { id = d.Id })
            })
            .ToList();

        return Ok(documents);
    }
}