using Microsoft.EntityFrameworkCore;
using UnifyApi.Domain.Abstractions.Repositories;
using UnifyApi.Domain.Abstractions.Services;
using UnifyApi.Domain.Profiles;
using UnifyApi.Domain.Services;
using UnifyApi.Persistance.Repositories;
using UnifyApi.Persistence;

namespace UnifyApi.App;

public static class Registration
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UnifyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UnifyDbContext")));

        services.AddTransient<IWidgetRepository, WidgetRepository>();
        services.AddTransient<IWidgetInstanceRepository, WidgetInstanceRepository>();
        services.AddTransient<IWidgetService, WidgetService>();
        services.AddTransient<IWidgetInstanceService, WidgetInstanceService>();

        services.AddAutoMapper(typeof(UnifyProfile));
    }
}

