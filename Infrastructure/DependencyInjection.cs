using Application.Persistence;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.ConfigureOptions<DatabaseOptionsSetup>();

            services.AddDbContext<DatabaseContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                DatabaseOptions databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
                {
                    sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                    sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);

                    //sqlServerAction.MigrationsAssembly("Infrastructure");
                });

                dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedError);

                dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
            });

            services.AddScoped<IGameRepository, GameRepository>();

            return services;
        }
    }
}
