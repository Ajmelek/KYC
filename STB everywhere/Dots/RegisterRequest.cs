using System.ComponentModel.DataAnnotations;

namespace STB_everywhere.Dots
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        
        [Required]
        public string Nom { get; set; }
        
        [Required]
        public string Prenom { get; set; }
    }
} 