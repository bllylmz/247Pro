using _247Pro.Core.Entity;
using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using _247Pro.Model.SeedData;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace _247Pro.Model.Context
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        
        public DbSet<UserAccount> Accounts { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<EstimatesAccounts> EstimatesAccounts { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleGroupPermissionDetail> RoleGroupPermissionDetails { get; set; }
        public DbSet<AccountRolePermission> AccountRolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMapping(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new RoleGroupSeedData());
            modelBuilder.ApplyConfiguration(new UserSeedData());
            modelBuilder.ApplyConfiguration(new RolePermissionSeedData());
            modelBuilder.ApplyConfiguration(new RoleGroupPermissionDetailSeedData());
        }

        private void RegisterMapping(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));
            foreach (var builderType in typeToRegister.Where(x => typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (builderType != null && builderType != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntites = ChangeTracker.Entries().Where(x=>x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Dns.GetHostEntry(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress).HostName;
            string iPAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();


            foreach (var item in modifiedEntites)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (entity != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedIP = iPAdress;
                            entity.CreatedDate = DateTime.Now;
                            //entity.CreatedUserId = GetUserId();
                            break;
                        case EntityState.Modified:
                            entity.ModifiedIP = iPAdress;
                            entity.ModifiedDate = DateTime.Now;
                            //entity.ModifiedUserId = GetUserId();
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        private Guid? GetUserId()
        {
            string userId = "";
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
                userId = claims?.FirstOrDefault(x => x.Type.Equals("jti", StringComparison.OrdinalIgnoreCase))?.Value;
            }

            if (userId != null)
                return Guid.Parse(userId);
            else
                return Guid.Empty;
        }
    }
}
