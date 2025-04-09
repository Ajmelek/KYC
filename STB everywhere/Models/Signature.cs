// Models/Signature.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    public class Signature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int KycApplicationId { get; set; }

        [Required]
        public string SignatureData { get; set; } // Base64 encoded signature image

        [Required]
        public DateTime SignatureDate { get; set; }
       
        public virtual KycApplication KycApplication { get; set; }
    }
}