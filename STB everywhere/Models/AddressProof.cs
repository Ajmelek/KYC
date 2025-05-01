// Models/AddressProof.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    public class AddressProof
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int KycApplicationId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProofType { get; set; } // "Passport", "UtilityBill", etc.

        [Required]
        public bool IsCorrespondenceAddress { get; set; }


        public virtual KycApplication KycApplication { get; set; }
    }
}