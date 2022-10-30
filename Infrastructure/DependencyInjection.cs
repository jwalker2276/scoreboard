using Application.Common.Dates;
using Application.Persistence;
using Domain.Entities;
using Infrastructure.Dates;
using Infrastructure.Options;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetup>();

        services.AddDbContext<DatabaseContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            DatabaseOptions databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);

            });

            dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedError);

            dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<IRepository<Game>, GameRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
