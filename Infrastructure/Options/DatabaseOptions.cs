namespace Infrastructure.Options
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; set; } = string.Empty;

        public int MaxRetryCount { get; set; } = 3;

        public int CommandTimeout { get; set; } = 30;

        public bool EnableDetailedError { get; set; } = false;

        public bool EnableSensitiveDataLogging { get; set; } = false;
    }
}
