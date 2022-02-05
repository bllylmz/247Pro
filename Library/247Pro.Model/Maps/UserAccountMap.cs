using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using _247Pro.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class UserAccountMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("Accounts");

                entity.HasExtended();

                entity.Property(e => e.CompanyAdress).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ImagePath).HasMaxLength(50);

                entity.Property(e => e.LoginEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.RoleGroup)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_RoleGroups");

            });
        }
    }
}
