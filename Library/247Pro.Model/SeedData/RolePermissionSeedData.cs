using System;
using System.Collections.Generic;
using System.Text;
using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _247Pro.Model.SeedData
{
    public class RolePermissionSeedData : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasData(

            #region Estimates
                new RolePermission
                {
                    Id = Guid.Parse("9ffc5fac-195c-49a5-9517-a3a6145c91f4"),
                    Code = "Estimates_List",
                    Value = true,
                    Group = "Estimates"
                },
                new RolePermission
                {
                    Id = Guid.Parse("96fb3f50-2383-48b9-8e11-e49f007099d8"),
                    Code = "Estimates_Create",
                    Value = true,
                    Group = "Estimates"
                },
                new RolePermission
                {
                    Id = Guid.Parse("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"),
                    Code = "Estimates_Update",
                    Value = true,
                    Group = "Estimates"
                },
                new RolePermission
                {
                    Id = Guid.Parse("fed1c430-7fb6-427e-b333-38f163770540"),
                    Code = "Estimates_Delete",
                    Value = true,
                    Group = "Estimates"
                },
            #endregion

            #region Accounts
                new RolePermission
                {
                    Id = Guid.Parse("7b7df018-8aa7-4786-b8a1-61141349693a"),
                    Code = "Account_List",
                    Value = true,
                    Group = "Accounts"
                },
                new RolePermission
                {
                    Id = Guid.Parse("ac5a257b-2353-4cf6-bb80-09e166532893"),
                    Code = "Account_Create",
                    Value = true,
                    Group = "Accounts"
                },
                new RolePermission
                {
                    Id = Guid.Parse("c9946a3b-1e96-4b61-844d-4c196908bf4a"),
                    Code = "Account_Update",
                    Value = true,
                    Group = "Accounts"
                },
                new RolePermission
                {
                    Id = Guid.Parse("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"),
                    Code = "Account_Delete",
                    Value = true,
                    Group = "Accounts"
                }
                #endregion

                );
        }
    }
}
