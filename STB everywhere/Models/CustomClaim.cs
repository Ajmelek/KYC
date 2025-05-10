namespace STB_everywhere.Models
{
    public class CustomClaim
    {
        public int Id { get; set; } // Primary key
        public string Type { get; set; }
        public string Value { get; set; }
        public string ValueType { get; set; }
        public string Issuer { get; set; }
        public string OriginalIssuer { get; set; }
        // Optional: Foreign key to relate to another entity like User
        public int? ClientID { get; set; }
        public Client Client { get; set; }
    }
}
