using System.ComponentModel.DataAnnotations.Schema;

namespace STB_everywhere.Models
{
    public class Reclamation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("ClientId")] // Add this to match database column
        public long ClientId { get; set; }

        public string Description { get; set; }

        [ForeignKey("ClientId")] 
        public Client Client { get; set; }
    }
}
