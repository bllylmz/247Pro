using Microsoft.Extensions.Configuration;

namespace _247Pro.Model.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
