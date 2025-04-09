// Dtos/KycApplicationDto.cs
using STB_everywhere.Dtos;

public class KycApplicationDto
{
    public int Id { get; set; }
    public DateTime ApplicationDate { get; set; }
    public string Status { get; set; }
    public ApplicantDetailDto ApplicantDetails { get; set; }
    public List<AddressDto> Addresses { get; set; }
    public List<AddressProofDto> AddressProofs { get; set; }
    public List<DocumentDto> Documents { get; set; }    
    public SignatureDto Signature { get; set; }
}

// Dtos/ApplicantDetailDto.cs
public class ApplicantDetailDto
{
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
}

// Other DTOs would follow similar patterns