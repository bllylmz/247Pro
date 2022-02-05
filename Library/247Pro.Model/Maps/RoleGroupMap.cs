using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using _247Pro.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class RoleGroupMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<RoleGroup>(entity =>
            {
                entity.ToTable("RoleGroups");

                entity.HasExtended();

                entity.Property(e => e.Name)
                     .IsRequired()
                     .HasMaxLength(50);

            });
        }
    }
}
