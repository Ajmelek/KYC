using System.ComponentModel.DataAnnotations;

namespace STB_everywhere.Dots
{
    public class LoginRequest
    {
        [Required]
        public string Username{ get; set; }
        
        [Required]
        public string Password { get; set; }
    }
} 