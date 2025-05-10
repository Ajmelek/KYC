using System.ComponentModel.DataAnnotations;

namespace STB_everywhere.Dots
{
    public class ClientLoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
