// Helpers/MappingProfiles.cs
using AutoMapper;
using STB_everywhere.Dtos;
using STB_everywhere.Models;
using System.Net;
using System.Reflection.Metadata;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<KycApplication, KycApplicationDto>().ReverseMap();
        CreateMap<ApplicantDetail, ApplicantDetailDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<AddressProof, AddressProofDto>().ReverseMap();
        CreateMap<STB_everywhere.Models.Document, DocumentDto>().ReverseMap();
        CreateMap<Signature, SignatureDto>().ReverseMap();
    }
}