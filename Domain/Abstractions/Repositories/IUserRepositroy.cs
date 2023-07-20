using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;
using BandHub.Persistence.Entities;

namespace BandHub.Domain.Abstractions.Repositories;

public interface IUserRepository : IGenericRepository<UserEntity, UserInput, UserOutput>
{


}