// Models/KycApplication.cs
using STB_everywhere.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata;

public class KycApplication
{
    public int Id { get; set; }
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";

    // Navigation properties
    public ApplicantDetail ApplicantDetails { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<AddressProof> AddressProofs { get; set; }
    public ICollection<STB_everywhere.Models.Document> Documents { get; set; }
    public Signature Signature { get; set; }
}

// Models/ApplicantDetail.cs
public class ApplicantDetail
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int KycApplicationId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherFirstName { get; set; }
    public string FatherLastName { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public string StatusType { get; set; }
    public string PanNumber { get; set; }
    public string IdentityProofType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public KycApplication KycApplication { get; set; }
}

// Other model classes (Address, AddressProof, Document, Signature) would follow similar patterns 