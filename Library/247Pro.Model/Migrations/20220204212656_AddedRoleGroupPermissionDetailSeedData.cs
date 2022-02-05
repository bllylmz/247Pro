using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _247Pro.Model.Migrations
{
    public partial class AddedRoleGroupPermissionDetailSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleGroupPermissionDetails_RoleGroups",
                table: "RoleGroupPermissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleGroupPermissionDetails_RolePermissions",
                table: "RoleGroupPermissionDetails");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d751f3ea-0ea3-476e-a830-055cc6572cae"));

            migrationBuilder.InsertData(
                table: "RoleGroups",
                columns: new[] { "Id", "CreatedDate", "CreatedIP", "ModifiedDate", "ModifiedIP", "Name" },
                values: new object[] { new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), null, null, null, null, "Management" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("1d0ebfe5-48d2-4708-bc01-39d367cfd8cf"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 5, 0, 26, 56, 39, DateTimeKind.Local).AddTicks(4515), "admin@admin.com", null, null, "admin", "123", new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be") });

            migrationBuilder.InsertData(
                table: "RoleGroupPermissionDetails",
                columns: new[] { "Id", "CreatedDate", "CreatedIP", "ModifiedDate", "ModifiedIP", "RoleGroupId", "RolePermissionId", "Value" },
                values: new object[,]
                {
                    { new Guid("fa72154b-36db-40d0-a459-9b52a8513f35"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("7b7df018-8aa7-4786-b8a1-61141349693a"), true },
                    { new Guid("1991ce31-c0df-48ec-9fbe-15eac2c979aa"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("ac5a257b-2353-4cf6-bb80-09e166532893"), true },
                    { new Guid("9315d058-6402-4136-af8c-be9d76f5d022"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("c9946a3b-1e96-4b61-844d-4c196908bf4a"), true },
                    { new Guid("11e45a2e-8733-4655-96f2-38fbce0ade62"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"), true },
                    { new Guid("721aaebc-8991-4827-a818-c6ce60b6cf9f"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("9ffc5fac-195c-49a5-9517-a3a6145c91f4"), true },
                    { new Guid("37d533b8-79b7-4d0a-a2ed-20b82c8e08f4"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("96fb3f50-2383-48b9-8e11-e49f007099d8"), true },
                    { new Guid("6ec18048-cc20-4614-b1e1-1ef7fd85be82"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"), true },
                    { new Guid("cd35cf75-310a-46bf-a8c7-131d53e97fe3"), null, null, null, null, new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), new Guid("fed1c430-7fb6-427e-b333-38f163770540"), true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleGroupPermissionDetails_RoleGroups",
                table: "RoleGroupPermissionDetails",
                column: "RoleGroupId",
                principalTable: "RoleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleGroupPermissionDetails_RolePermissions",
                table: "RoleGroupPermissionDetails",
                column: "RolePermissionId",
                principalTable: "RolePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleGroupPermissionDetails_RoleGroups",
                table: "RoleGroupPermissionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleGroupPermissionDetails_RolePermissions",
                table: "RoleGroupPermissionDetails");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1d0ebfe5-48d2-4708-bc01-39d367cfd8cf"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("11e45a2e-8733-4655-96f2-38fbce0ade62"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("1991ce31-c0df-48ec-9fbe-15eac2c979aa"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("37d533b8-79b7-4d0a-a2ed-20b82c8e08f4"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("6ec18048-cc20-4614-b1e1-1ef7fd85be82"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("721aaebc-8991-4827-a818-c6ce60b6cf9f"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("9315d058-6402-4136-af8c-be9d76f5d022"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("cd35cf75-310a-46bf-a8c7-131d53e97fe3"));

            migrationBuilder.DeleteData(
                table: "RoleGroupPermissionDetails",
                keyColumn: "Id",
                keyValue: new Guid("fa72154b-36db-40d0-a459-9b52a8513f35"));

            migrationBuilder.DeleteData(
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("d751f3ea-0ea3-476e-a830-055cc6572cae"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 4, 23, 22, 44, 308, DateTimeKind.Local).AddTicks(7860), "admin@admin.com", null, null, "admin", "123", null });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleGroupPermissionDetails_RoleGroups",
                table: "RoleGroupPermissionDetails",
                column: "RoleGroupId",
                principalTable: "RoleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleGroupPermissionDetails_RolePermissions",
                table: "RoleGroupPermissionDetails",
                column: "RolePermissionId",
                principalTable: "RolePermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
