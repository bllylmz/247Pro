using _247Pro.Core.Entity;
using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class AccountRolePermissionMap : CoreEntity
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<AccountRolePermission>(entity =>
            {
                entity.HasOne(d => d.Account)
                     .WithMany(p => p.AccountRolePermissions)
                     .HasForeignKey(d => d.AccountId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_UserRolePermissions_Accounts");

                entity.HasOne(d => d.RolePermission)
                    .WithMany(p => p.AccountRolePermissions)
                    .HasForeignKey(d => d.RolePermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRolePermissions_RolePermissions");

            });
        }
    }
}
