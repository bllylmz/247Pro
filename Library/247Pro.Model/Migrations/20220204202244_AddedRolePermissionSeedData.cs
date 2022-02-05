using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _247Pro.Model.Migrations
{
    public partial class AddedRolePermissionSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("170f8846-d5fe-4f4f-99f6-21acf23a71c0"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("d751f3ea-0ea3-476e-a830-055cc6572cae"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 4, 23, 22, 44, 308, DateTimeKind.Local).AddTicks(7860), "admin@admin.com", null, null, "admin", "123", null });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedIP", "Group", "ModifiedDate", "ModifiedIP", "Value" },
                values: new object[,]
                {
                    { new Guid("9ffc5fac-195c-49a5-9517-a3a6145c91f4"), "Estimates_List", null, null, "Estimates", null, null, true },
                    { new Guid("96fb3f50-2383-48b9-8e11-e49f007099d8"), "Estimates_Create", null, null, "Estimates", null, null, true },
                    { new Guid("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"), "Estimates_Update", null, null, "Estimates", null, null, true },
                    { new Guid("fed1c430-7fb6-427e-b333-38f163770540"), "Estimates_Delete", null, null, "Estimates", null, null, true },
                    { new Guid("7b7df018-8aa7-4786-b8a1-61141349693a"), "Account_List", null, null, "Accounts", null, null, true },
                    { new Guid("ac5a257b-2353-4cf6-bb80-09e166532893"), "Account_Create", null, null, "Accounts", null, null, true },
                    { new Guid("c9946a3b-1e96-4b61-844d-4c196908bf4a"), "Account_Update", null, null, "Accounts", null, null, true },
                    { new Guid("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"), "Account_Delete", null, null, "Accounts", null, null, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d751f3ea-0ea3-476e-a830-055cc6572cae"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("7b7df018-8aa7-4786-b8a1-61141349693a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("96fb3f50-2383-48b9-8e11-e49f007099d8"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("9ffc5fac-195c-49a5-9517-a3a6145c91f4"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ac5a257b-2353-4cf6-bb80-09e166532893"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c9946a3b-1e96-4b61-844d-4c196908bf4a"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fed1c430-7fb6-427e-b333-38f163770540"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("170f8846-d5fe-4f4f-99f6-21acf23a71c0"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 3, 17, 58, 20, 320, DateTimeKind.Local).AddTicks(4324), "admin@admin.com", null, null, "admin", "123", null });
        }
    }
}
