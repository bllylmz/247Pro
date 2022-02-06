using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _247Pro.Model.Migrations
{
    public partial class AddedSubAccountFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("1d0ebfe5-48d2-4708-bc01-39d367cfd8cf"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubAccountId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId", "SubAccountId" },
                values: new object[] { new Guid("9529345f-7702-4427-9409-6e1a78fe1fb3"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 6, 9, 45, 18, 847, DateTimeKind.Local).AddTicks(4582), "admin@admin.com", null, null, "admin", "123", new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"), null });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SubAccountId",
                table: "Accounts",
                column: "SubAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts",
                table: "Accounts",
                column: "SubAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SubAccountId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("9529345f-7702-4427-9409-6e1a78fe1fb3"));

            migrationBuilder.DropColumn(
                name: "SubAccountId",
                table: "Accounts");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("1d0ebfe5-48d2-4708-bc01-39d367cfd8cf"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 5, 0, 26, 56, 39, DateTimeKind.Local).AddTicks(4515), "admin@admin.com", null, null, "admin", "123", new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be") });
        }
    }
}
