using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class RolePermissionMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermissions");

                entity.Property(e => e.Code)
                   .IsRequired()
                   .HasMaxLength(50);

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
