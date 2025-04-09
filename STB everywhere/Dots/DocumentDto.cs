// Dtos/DocumentDto.cs
namespace STB_everywhere.Dtos
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string DocumentType { get; set; }
        public DateTime UploadDate { get; set; }
        public string DownloadUrl { get; set; } // Will be generated in controller
    }
}