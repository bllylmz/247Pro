using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _247Pro.Model.SeedData
{
    public class RoleGroupSeedData : IEntityTypeConfiguration<RoleGroup>
    {
        public void Configure(EntityTypeBuilder<RoleGroup> builder)
        {
            builder.HasData(new RoleGroup { Id = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"), Name = "Management" });
        }
    }
}
