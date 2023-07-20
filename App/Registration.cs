using Microsoft.EntityFrameworkCore;
using BandHub.Domain.Abstractions.Repositories;
using BandHub.Domain.Abstractions.Services;
using BandHub.Domain.Profiles;
using BandHub.Domain.Services;
using BandHub.Persistence;
using BandHub.Persistence.Repositories;

namespace BandHub.App;

public static class Registration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BandHubContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UnifyDbContext")));

        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserService, UserService>();

        services.AddAutoMapper(typeof(BandHubProfile));
    }
}

