using BandHub.Domain.Abstractions.Repositories;
using BandHub.Domain.Abstractions.Services;
using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;
using BCrypt.Net;

namespace BandHub.Domain.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserOutput>> Get(CancellationToken ct)
    {
        return await _repository.Get(ct);
    }

    public async Task<UserOutput> Get(Guid id, CancellationToken ct)
    {
        return await _repository.Get(id, ct);
    }

    public async Task<UserOutput> Create(UserInput input, CancellationToken ct)
    {
        input.Password = BCrypt.Net.BCrypt.HashPassword(input.Password);

        return await _repository.Create(input, ct);
    }

    public async Task<UserOutput> Update(Guid id, UserInput input, CancellationToken ct)
    {
        return await _repository.Update(id, input, ct);
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _repository.Delete(id, ct);
    }

    public async Task<UserOutput?> Login(LoginInput input, CancellationToken ct)
    {
        var user = (await _repository.Find(user => user.Email == input.Email, ct)).SingleOrDefault();

        if (user == null) return null;

        var matchingPassword = BCrypt.Net.BCrypt.Verify(input.Password, user.Password, false, HashType.SHA384);

        return !!matchingPassword ? user : null;
    }

    public async Task<bool> VerifyEmail(string email, CancellationToken ct)
    {
        var users = await _repository.Find(user => user.Email.ToLower() == email.ToLower(), ct);

        return users.Count() == 0;
    }


}
