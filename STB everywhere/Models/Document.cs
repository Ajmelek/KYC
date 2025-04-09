// Models/Document.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int KycApplicationId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        [StringLength(100)]
        public string DocumentType { get; set; } // e.g., "Passport", "UtilityBill"

        [Required]
        public DateTime UploadDate { get; set; }

        
        public virtual KycApplication KycApplication { get; set; }
    }
}