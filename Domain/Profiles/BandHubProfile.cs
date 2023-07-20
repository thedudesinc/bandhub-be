using AutoMapper;
using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;
using BandHub.Persistence.Entities;

namespace BandHub.Domain.Profiles;

public class BandHubProfile : Profile
{
    public BandHubProfile()
    {
        CreateMap<UserInput, UserEntity>();
        CreateMap<UserEntity, UserOutput>();

    }
}
