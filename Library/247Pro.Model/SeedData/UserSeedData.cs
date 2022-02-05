using _247Pro.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _247Pro.Model.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasData(
                new UserAccount
                {
                    Id = Guid.NewGuid(),
                    LoginEmail = "admin@admin.com",
                    PasswordHash = "123",
                    Name = "admin",
                    CompanyName = "admin",
                    CompanyAdress = "Admin",
                    ImagePath = "/",
                    LastLogin = DateTime.Now,
                    LastIPAdress = "127.0.0.1",
                    RoleGroupId = Guid.Parse("1A4D7FBE-3C72-43F0-8CD4-05A5B1C667BE")
                });
        }
    }
}
