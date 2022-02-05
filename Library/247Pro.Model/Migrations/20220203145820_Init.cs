using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _247Pro.Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Adress = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<bool>(nullable: false),
                    Group = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LoginEmail = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyAdress = table.Column<string>(maxLength: 50, nullable: true),
                    RoleGroupId = table.Column<Guid>(nullable: true),
                    LastIPAdress = table.Column<string>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_RoleGroups",
                        column: x => x.RoleGroupId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupPermissionDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RoleGroupId = table.Column<Guid>(nullable: false),
                    RolePermissionId = table.Column<Guid>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupPermissionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleGroupPermissionDetails_RoleGroups",
                        column: x => x.RoleGroupId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleGroupPermissionDetails_RolePermissions",
                        column: x => x.RolePermissionId,
                        principalTable: "RolePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountRolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedIP = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedIP = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: false),
                    RolePermissionId = table.Column<Guid>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRolePermissions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRolePermissions_RolePermissions_RolePermissionId",
                        column: x => x.RolePermissionId,
                        principalTable: "RolePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesAccounts",
                columns: table => new
                {
                    EstimateId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesAccounts", x => new { x.EstimateId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_EstimatesAccounts_Accounts",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstimatesAccounts_Estimates",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CompanyAdress", "CompanyName", "CreatedDate", "CreatedIP", "ImagePath", "LastIPAdress", "LastLogin", "LoginEmail", "ModifiedDate", "ModifiedIP", "Name", "PasswordHash", "RoleGroupId" },
                values: new object[] { new Guid("170f8846-d5fe-4f4f-99f6-21acf23a71c0"), "Admin", "admin", null, null, "/", "127.0.0.1", new DateTime(2022, 2, 3, 17, 58, 20, 320, DateTimeKind.Local).AddTicks(4324), "admin@admin.com", null, null, "admin", "123", null });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRolePermissions_AccountId",
                table: "AccountRolePermissions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRolePermissions_RolePermissionId",
                table: "AccountRolePermissions",
                column: "RolePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleGroupId",
                table: "Accounts",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesAccounts_AccountId",
                table: "EstimatesAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupPermissionDetails_RoleGroupId",
                table: "RoleGroupPermissionDetails",
                column: "RoleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupPermissionDetails_RolePermissionId",
                table: "RoleGroupPermissionDetails",
                column: "RolePermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRolePermissions");

            migrationBuilder.DropTable(
                name: "EstimatesAccounts");

            migrationBuilder.DropTable(
                name: "RoleGroupPermissionDetails");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Estimates");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "RoleGroups");
        }
    }
}
