using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _247Pro.Model.SeedData
{
    public class RoleGroupPermissionDetailSeedData : IEntityTypeConfiguration<RoleGroupPermissionDetail>
    {
        public void Configure(EntityTypeBuilder<RoleGroupPermissionDetail> builder)
        {
            builder.HasData(
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("fa72154b-36db-40d0-a459-9b52a8513f35"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("7b7df018-8aa7-4786-b8a1-61141349693a"), //Account_List
                    Value = true
                },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("1991ce31-c0df-48ec-9fbe-15eac2c979aa"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("ac5a257b-2353-4cf6-bb80-09e166532893"),//Account_Create
                    Value = true
                },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("9315d058-6402-4136-af8c-be9d76f5d022"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("c9946a3b-1e96-4b61-844d-4c196908bf4a"),//Account_Update
                    Value = true
                },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("11e45a2e-8733-4655-96f2-38fbce0ade62"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"),//Account_Delete
                    Value = true
                },
                 new RoleGroupPermissionDetail
                 {
                     Id = Guid.Parse("721AAEBC-8991-4827-A818-C6CE60B6CF9F"),
                     RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                     RolePermissionId = Guid.Parse("9ffc5fac-195c-49a5-9517-a3a6145c91f4"), //Estimates_List
                     Value = true
                 },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("37D533B8-79B7-4D0A-A2ED-20B82C8E08F4"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("96fb3f50-2383-48b9-8e11-e49f007099d8"),//Estimates_Create
                    Value = true
                },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("6EC18048-CC20-4614-B1E1-1EF7FD85BE82"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"),//Estimates_Update
                    Value = true
                },
                new RoleGroupPermissionDetail
                {
                    Id = Guid.Parse("CD35CF75-310A-46BF-A8C7-131D53E97FE3"),
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE"),//Management
                    RolePermissionId = Guid.Parse("fed1c430-7fb6-427e-b333-38f163770540"),//Estimates_Delete
                    Value = true
                }
                );
        }
    }
}
