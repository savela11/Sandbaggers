using API.Repositories;
using API.Repositories.Interface;
using API.Services;
using API.Services.Interface;

namespace API.Config;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IService, Service>();
        // services.AddTransient<IUserService, UserService>();
        // services.AddTransient<IAuthService, AuthService>();
        services.AddScoped<IRepository, Repository>();
    }
}