using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    [Table("SuperAdmin")]
    public class SuperAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Password")]
        public string Password { get; set; }
    }
}
