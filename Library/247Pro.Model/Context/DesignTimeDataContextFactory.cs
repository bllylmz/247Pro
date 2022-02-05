using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace _247Pro.Model.Context
{
    public class DesignTimeDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../247Pro.API")
            };
            return resolver.ServiceProvider.GetService(typeof(DataContext)) as DataContext;
        }
    }
}
