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
    [Migration("20220203145820_Init")]
    partial class Init
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

                    b.HasKey("Id");

                    b.HasIndex("RoleGroupId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("170f8846-d5fe-4f4f-99f6-21acf23a71c0"),
                            CompanyAdress = "Admin",
                            CompanyName = "admin",
                            ImagePath = "/",
                            LastIPAdress = "127.0.0.1",
                            LastLogin = new DateTime(2022, 2, 3, 17, 58, 20, 320, DateTimeKind.Local).AddTicks(4324),
                            LoginEmail = "admin@admin.com",
                            Name = "admin",
                            PasswordHash = "123"
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
                        .IsRequired();

                    b.HasOne("_247Pro.Model.Entities.RolePermission", "RolePermission")
                        .WithMany("RoleGroupPermissionDetails")
                        .HasForeignKey("RolePermissionId")
                        .HasConstraintName("FK_RoleGroupPermissionDetails_RolePermissions")
                        .IsRequired();
                });

            modelBuilder.Entity("_247Pro.Model.Entities.UserAccount", b =>
                {
                    b.HasOne("_247Pro.Model.Entities.RoleGroup", "RoleGroup")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleGroupId")
                        .HasConstraintName("FK_Accounts_RoleGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
