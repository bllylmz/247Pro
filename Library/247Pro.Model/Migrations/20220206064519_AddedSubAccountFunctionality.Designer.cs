// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _247Pro.Model.Context;

namespace _247Pro.Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220206064519_AddedSubAccountFunctionality")]
    partial class AddedSubAccountFunctionality
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("_247Pro.Model.Entities.AccountRolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("text");

                    b.Property<Guid>("RolePermissionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Value")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RolePermissionId");

                    b.ToTable("AccountRolePermissions");
                });

            modelBuilder.Entity("_247Pro.Model.Entities.Estimate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Adress")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Description")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Title")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Estimates");
                });

            modelBuilder.Entity("_247Pro.Model.Entities.EstimatesAccounts", b =>
                {
                    b.Property<Guid>("EstimateId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.HasKey("EstimateId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("EstimatesAccounts");
                });

            modelBuilder.Entity("_247Pro.Model.Entities.RoleGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("RoleGroups");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            Name = "Management"
                        });
                });

            modelBuilder.Entity("_247Pro.Model.Entities.RoleGroupPermissionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RolePermissionId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Value")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.HasIndex("RolePermissionId");

                    b.ToTable("RoleGroupPermissionDetails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa72154b-36db-40d0-a459-9b52a8513f35"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("7b7df018-8aa7-4786-b8a1-61141349693a"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("1991ce31-c0df-48ec-9fbe-15eac2c979aa"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("ac5a257b-2353-4cf6-bb80-09e166532893"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("9315d058-6402-4136-af8c-be9d76f5d022"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("c9946a3b-1e96-4b61-844d-4c196908bf4a"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("11e45a2e-8733-4655-96f2-38fbce0ade62"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("721aaebc-8991-4827-a818-c6ce60b6cf9f"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("9ffc5fac-195c-49a5-9517-a3a6145c91f4"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("37d533b8-79b7-4d0a-a2ed-20b82c8e08f4"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("96fb3f50-2383-48b9-8e11-e49f007099d8"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("6ec18048-cc20-4614-b1e1-1ef7fd85be82"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"),
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("cd35cf75-310a-46bf-a8c7-131d53e97fe3"),
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be"),
                            RolePermissionId = new Guid("fed1c430-7fb6-427e-b333-38f163770540"),
                            Value = true
                        });
                });

            modelBuilder.Entity("_247Pro.Model.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("text");

                    b.Property<bool>("Value")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ffc5fac-195c-49a5-9517-a3a6145c91f4"),
                            Code = "Estimates_List",
                            Group = "Estimates",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("96fb3f50-2383-48b9-8e11-e49f007099d8"),
                            Code = "Estimates_Create",
                            Group = "Estimates",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("76a9bf0e-9ee3-4104-b5d2-dd93f4dd9cc7"),
                            Code = "Estimates_Update",
                            Group = "Estimates",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("fed1c430-7fb6-427e-b333-38f163770540"),
                            Code = "Estimates_Delete",
                            Group = "Estimates",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("7b7df018-8aa7-4786-b8a1-61141349693a"),
                            Code = "Account_List",
                            Group = "Accounts",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("ac5a257b-2353-4cf6-bb80-09e166532893"),
                            Code = "Account_Create",
                            Group = "Accounts",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("c9946a3b-1e96-4b61-844d-4c196908bf4a"),
                            Code = "Account_Update",
                            Group = "Accounts",
                            Value = true
                        },
                        new
                        {
                            Id = new Guid("25e16ebd-bf0c-4d0e-a1b6-7d2cbfc83b49"),
                            Code = "Account_Delete",
                            Group = "Accounts",
                            Value = true
                        });
                });

            modelBuilder.Entity("_247Pro.Model.Entities.UserAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyAdress")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("ImagePath")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastIPAdress")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LoginEmail")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedIP")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("RoleGroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubAccountId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.HasIndex("SubAccountId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9529345f-7702-4427-9409-6e1a78fe1fb3"),
                            CompanyAdress = "Admin",
                            CompanyName = "admin",
                            ImagePath = "/",
                            LastIPAdress = "127.0.0.1",
                            LastLogin = new DateTime(2022, 2, 6, 9, 45, 18, 847, DateTimeKind.Local).AddTicks(4582),
                            LoginEmail = "admin@admin.com",
                            Name = "admin",
                            PasswordHash = "123",
                            RoleGroupId = new Guid("1a4d7fbe-3c72-43f0-8cd4-05a5b1c667be")
                        });
                });

            modelBuilder.Entity("_247Pro.Model.Entities.AccountRolePermission", b =>
                {
                    b.HasOne("_247Pro.Model.Entities.UserAccount", "Account")
                        .WithMany("AccountRolePermissions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_247Pro.Model.Entities.RolePermission", "RolePermission")
                        .WithMany("AccountRolePermissions")
                        .HasForeignKey("RolePermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_247Pro.Model.Entities.EstimatesAccounts", b =>
                {
                    b.HasOne("_247Pro.Model.Entities.UserAccount", "Account")
                        .WithMany("EstimatesAccounts")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_EstimatesAccounts_Accounts")
                        .IsRequired();

                    b.HasOne("_247Pro.Model.Entities.Estimate", "Estimate")
                        .WithMany("EstimatesAccounts")
                        .HasForeignKey("EstimateId")
                        .HasConstraintName("FK_EstimatesAccounts_Estimates")
                        .IsRequired();
                });

            modelBuilder.Entity("_247Pro.Model.Entities.RoleGroupPermissionDetail", b =>
                {
                    b.HasOne("_247Pro.Model.Entities.RoleGroup", "RoleGroup")
                        .WithMany("RoleGroupPermissionDetails")
                        .HasForeignKey("RoleGroupId")
                        .HasConstraintName("FK_RoleGroupPermissionDetails_RoleGroups")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_247Pro.Model.Entities.RolePermission", "RolePermission")
                        .WithMany("RoleGroupPermissionDetails")
                        .HasForeignKey("RolePermissionId")
                        .HasConstraintName("FK_RoleGroupPermissionDetails_RolePermissions")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_247Pro.Model.Entities.UserAccount", b =>
                {
                    b.HasOne("_247Pro.Model.Entities.RoleGroup", "RoleGroup")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleGroupId")
                        .HasConstraintName("FK_Accounts_RoleGroups");

                    b.HasOne("_247Pro.Model.Entities.UserAccount", "SubAccount")
                        .WithMany("SubAccounts")
                        .HasForeignKey("SubAccountId")
                        .HasConstraintName("FK_Accounts_Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
