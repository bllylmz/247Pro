using _247Pro.Core.Map;
using _247Pro.Model.Entities;
using _247Pro.Model.Maps.Base;
using Microsoft.EntityFrameworkCore;

namespace _247Pro.Model.Maps
{
    public class EstimateMap : IEntityBuilder
    {
        public void Build(ModelBuilder builder)
        {
            builder.Entity<Estimate>(entity =>
            {
                entity.ToTable("Estimates");

                entity.HasExtended();

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

            });
        }
    }

}
