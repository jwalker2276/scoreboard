using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Options
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;

        private const string _databaseConnectionStringName = "Database";

        private const string _databaseOptionsSectionName = "DatabaseOptions";

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options)
        {
            var connectionString = _configuration.GetConnectionString(_databaseConnectionStringName);

            options.ConnectionString = connectionString;

            _configuration.GetSection(_databaseOptionsSectionName).Bind(options);
        }
    }
}
