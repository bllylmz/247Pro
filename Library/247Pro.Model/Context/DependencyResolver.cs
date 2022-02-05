using _247Pro.Model.Services.ConfigurationService;
using _247Pro.Model.Services.EnvironmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _247Pro.Model.Context
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            // Set up Dependency Injection
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>(provider =>
                 new ConfigurationService(provider.GetService<IEnvironmentService>())
                 {
                     CurrentDirectory = this.CurrentDirectory
                 });

            // Register DbContext class
            services.AddTransient(provider =>
            {
                var optionBuilder = new DbContextOptionsBuilder<DataContext>();
                var configService = provider.GetService<IConfigurationService>();

                var connectionString = configService.GetConfiguration().GetConnectionString("Conn");
                optionBuilder.UseNpgsql(connectionString, builder => builder.MigrationsAssembly("247Pro.Model"));
                optionBuilder.EnableSensitiveDataLogging();

                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                return new DataContext(optionBuilder.Options, httpContextAccessor);
            });
        }
    }
}
