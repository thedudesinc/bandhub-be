using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;

namespace BandHub.Domain.Abstractions.Services;

public interface IUserService
{
    Task<IEnumerable<UserOutput>> Get(CancellationToken ct);

    Task<UserOutput> Get(Guid id, CancellationToken ct);

    Task<UserOutput> Create(UserInput input, CancellationToken ct);

    Task<UserOutput> Update(Guid id, UserInput input, CancellationToken ct);

    Task Delete(Guid id, CancellationToken ct);

    Task<UserOutput?> Login(LoginInput input, CancellationToken ct);

    Task<bool> VerifyEmail(string email, CancellationToken ct);


}
