﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SIWES_BSSL.Data;

namespace SIWES_BSSL.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200227115416_updatetables")]
    partial class updatetables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Menu.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Menu.SubMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuId");

                    b.Property<string>("Name");

                    b.Property<string>("PageUrl");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("SubMenu");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.AgencySuperSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("CPersonEmail");

                    b.Property<string>("City");

                    b.Property<string>("Code");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DeactDate");

                    b.Property<bool>("Deactivate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("NameOfCPerson");

                    b.Property<string>("PhoneNo");

                    b.Property<string>("ShortCode");

                    b.Property<string>("State");

                    b.Property<string>("WebAddress");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("AgencySuperSetup");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.CourseGrpSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("InstTypeId");

                    b.Property<int?>("InstTypeSetupId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortCode");

                    b.HasKey("Id");

                    b.HasIndex("InstTypeSetupId");

                    b.ToTable("CourseGrpSetup");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("CourseGrpSetupId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortCode");

                    b.HasKey("Id");

                    b.HasIndex("CourseGrpSetupId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.InstCarryCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowDisporal");

                    b.Property<bool>("DelistInst");

                    b.Property<string>("InstypeId");

                    b.Property<DateTime>("MasterListDate");

                    b.Property<int>("MaxSiwesCap");

                    b.Property<int>("MinVisit4Super");

                    b.Property<bool>("MustNotExcCap");

                    b.Property<decimal>("StudentAmt");

                    b.Property<decimal>("SuperAmt");

                    b.HasKey("Id");

                    b.ToTable("InstCarryCap");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.InstCatSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InstCatSetup");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.InstLevelStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InstLevelStudy");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.InstTypeSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencySuperSetupId");

                    b.Property<string>("Code");

                    b.Property<int>("InstCatSetupId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AgencySuperSetupId");

                    b.HasIndex("InstCatSetupId");

                    b.ToTable("InstTypeSetup");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("AffiliateInst");

                    b.Property<string>("AreaOffice");

                    b.Property<int>("CapacityNo");

                    b.Property<string>("City");

                    b.Property<string>("Code");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Datedectivated");

                    b.Property<bool>("Deactivate");

                    b.Property<string>("InstCatSetupId");

                    b.Property<int?>("InstCatSetupId1");

                    b.Property<string>("InstTypeSetupId");

                    b.Property<int?>("InstTypeSetupId1");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo1");

                    b.Property<string>("PhoneNo2");

                    b.Property<string>("ShortCode");

                    b.Property<string>("State");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("InstCatSetupId1");

                    b.HasIndex("InstTypeSetupId1");

                    b.ToTable("Institution");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.PolicyTb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowDisporal");

                    b.Property<bool>("DelistInst");

                    b.Property<string>("InstypeId");

                    b.Property<DateTime>("MasterListDate");

                    b.Property<int>("MaxSiwesCap");

                    b.Property<int>("MinVisit4Super");

                    b.Property<bool>("MustNotExcCap");

                    b.Property<decimal>("StudentAmt");

                    b.Property<decimal>("SuperAmt");

                    b.HasKey("Id");

                    b.ToTable("PolicyTb");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Menu.SubMenu", b =>
                {
                    b.HasOne("SIWES_BSSL.Data.Menu.Menu", "Menu")
                        .WithMany("SubMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.CourseGrpSetup", b =>
                {
                    b.HasOne("SIWES_BSSL.Data.Setup.InstTypeSetup", "InstTypeSetup")
                        .WithMany()
                        .HasForeignKey("InstTypeSetupId");
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.Courses", b =>
                {
                    b.HasOne("SIWES_BSSL.Data.Setup.CourseGrpSetup", "CourseGrpSetup")
                        .WithMany()
                        .HasForeignKey("CourseGrpSetupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.InstTypeSetup", b =>
                {
                    b.HasOne("SIWES_BSSL.Data.Setup.AgencySuperSetup", "AgencySuperSetup")
                        .WithMany()
                        .HasForeignKey("AgencySuperSetupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SIWES_BSSL.Data.Setup.InstCatSetup", "InstCatSetup")
                        .WithMany("InstTypes")
                        .HasForeignKey("InstCatSetupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SIWES_BSSL.Data.Setup.Institution", b =>
                {
                    b.HasOne("SIWES_BSSL.Data.Setup.InstCatSetup", "InstCatSetup")
                        .WithMany()
                        .HasForeignKey("InstCatSetupId1");

                    b.HasOne("SIWES_BSSL.Data.Setup.InstTypeSetup", "InstTypeSetup")
                        .WithMany()
                        .HasForeignKey("InstTypeSetupId1");
                });
#pragma warning restore 612, 618
        }
    }
}
