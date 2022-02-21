using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public static class Configuration
    {
        public static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
                .AddUserSecrets<AppDbContext>()
                .Build();
    }
}
