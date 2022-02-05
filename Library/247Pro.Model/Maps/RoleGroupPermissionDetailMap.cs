using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class RoleGroupPermissionDetailMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<RoleGroupPermissionDetail>(entity =>
            {
                entity.ToTable("RoleGroupPermissionDetails");

                entity.HasOne(d => d.RoleGroup)
                    .WithMany(p => p.RoleGroupPermissionDetails)
                    .HasForeignKey(d => d.RoleGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RoleGroupPermissionDetails_RoleGroups");

                entity.HasOne(d => d.RolePermission)
                    .WithMany(p => p.RoleGroupPermissionDetails)
                    .HasForeignKey(d => d.RolePermissionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RoleGroupPermissionDetails_RolePermissions");

            });
        }
    }

}
