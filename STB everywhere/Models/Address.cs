using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("KycApplication")]
        public int KycApplicationId { get; set; }  // Only ONE foreign key property

        [Required]
        [StringLength(20)]
        public string AddressType { get; set; } // "Correspondence" or "Permanent"

        [Required]
        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        // Navigation property
        public virtual KycApplication KycApplication { get; set; }
    }
}