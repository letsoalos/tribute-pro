using API.Dtos;
using AutoMapper;
using Core.Clients.Entities;
using Core.Dtos;

namespace API.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(d => d.IdentityType, o => o.MapFrom(s => s.IdentityType.Name))
            .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender.Name))
            .ForMember(d => d.Title, o => o.MapFrom(s => s.Title.Name))
            .ForMember(d => d.Ethnicity, o => o.MapFrom(s => s.Ethnicity.Name))
            .ForMember(d => d.MaritalStatus, o => o.MapFrom(s => s.MaritalStatus.Name))
            .ForMember(d => d.BurialSociety, o => o.MapFrom(s => s.BurialSociety!.Name))
            .ForMember(d => d.BurialPlan, o => o.MapFrom(s => s.BurialPlan.Name))
            .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name));

        CreateMap<ClientDto, Client>()
            .ForMember(d => d.IdentityType, o => o.Ignore())
            .ForMember(d => d.Gender, o => o.Ignore())
            .ForMember(d => d.Title, o => o.Ignore())
            .ForMember(d => d.Ethnicity, o => o.Ignore())
            .ForMember(d => d.MaritalStatus, o => o.Ignore())
            .ForMember(d => d.BurialSociety, o => o.Ignore())
             .ForMember(d => d.BurialPlan, o => o.Ignore())
            .ForMember(d => d.Branch, o => o.Ignore());

        CreateMap<Client, DashboardRecentClientDto>()
           .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"))
           .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.Name))
           .ForMember(d => d.BurialSociety, o => o.MapFrom(s => s.BurialSociety!.Name));
    }
}
