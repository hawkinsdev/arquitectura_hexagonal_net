// MyApp.Shared/Extensions/ServiceRegistration.cs
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Infrastructure.Repositories;


public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<UserRepository>();
        // Agrega otros servicios aquí
    }
}
