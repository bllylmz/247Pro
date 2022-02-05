using _247Pro.Model.Services.EnvironmentService;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace _247Pro.Model.Services.ConfigurationService
{
    public class ConfigurationService : IConfigurationService
    {
        private IEnvironmentService _env { get; }
        public string CurrentDirectory { get; set; }
        public ConfigurationService(IEnvironmentService env)
        {
            _env = env;
        }

        public IConfiguration GetConfiguration()
        {
            CurrentDirectory = CurrentDirectory ?? Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables()
                 .Build();
        }
    }
}
