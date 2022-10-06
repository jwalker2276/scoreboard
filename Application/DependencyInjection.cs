using Application.Services.GameService.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGameCommandService, GameCommandService>();

        return services;
    }
}