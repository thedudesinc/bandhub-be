using AutoMapper;
using BandHub.Domain.Abstractions.Repositories;
using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;
using BandHub.Persistence.Entities;

namespace BandHub.Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity, UserInput, UserOutput>, IUserRepository
{
// Figure out what this context is doing and either change name or change use
    public UserRepository( BandHubContext context, IMapper mapper) : base(context, mapper)
    {
    }
}