using Application.Persistence;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();

            return services;
        }
    }
}
