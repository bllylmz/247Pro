﻿using _247Pro.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _247Pro.Model.Maps.Base
{
    public static class EntityBuilderExtension
    {
        public static void HasExtended<T>(this EntityTypeBuilder<T> entity) where T : CoreEntity
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x=>x.CreatedDate).IsRequired(false);
            entity.Property(x=>x.CreatedIP).HasMaxLength(15).IsRequired(false);

            entity.Property(x => x.ModifiedDate).IsRequired(false);
            entity.Property(x => x.ModifiedIP).HasMaxLength(15).IsRequired(false);
        }
    }
}
