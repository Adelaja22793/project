using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIWES_BSSL.Migrations
{
    public partial class siwetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencySuperSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    NameOfCPerson = table.Column<string>(nullable: true),
                    CPersonEmail = table.Column<string>(nullable: true),
                    Deactivate = table.Column<bool>(nullable: false),
                    DeactDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencySuperSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaOffices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstCarryCap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstypeId = table.Column<string>(nullable: true),
                    MustNotExcCap = table.Column<bool>(nullable: false),
                    MaxSiwesCap = table.Column<int>(nullable: false),
                    AllowDisporal = table.Column<bool>(nullable: false),
                    SuperAmt = table.Column<decimal>(nullable: false),
                    StudentAmt = table.Column<decimal>(nullable: false),
                    MinVisit4Super = table.Column<int>(nullable: false),
                    MasterListDate = table.Column<DateTime>(nullable: false),
                    DelistInst = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstCarryCap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstCatSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstCatSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstLevelStudy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstLevelStudy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstypeId = table.Column<string>(nullable: true),
                    MustNotExcCap = table.Column<bool>(nullable: false),
                    MaxSiwesCap = table.Column<int>(nullable: false),
                    AllowDisporal = table.Column<bool>(nullable: false),
                    SuperAmt = table.Column<decimal>(nullable: false),
                    StudentAmt = table.Column<decimal>(nullable: false),
                    MinVisit4Super = table.Column<int>(nullable: false),
                    MasterListDate = table.Column<DateTime>(nullable: false),
                    DelistInst = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployerSuperSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    YearOfIncop = table.Column<string>(nullable: true),
                    AreaOfficeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerSuperSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerSuperSetups_AreaOffices_AreaOfficeId",
                        column: x => x.AreaOfficeId,
                        principalTable: "AreaOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstTypeSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    InstCatSetupId = table.Column<int>(nullable: false),
                    AgencySuperSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstTypeSetup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstTypeSetup_AgencySuperSetup_AgencySuperSetupId",
                        column: x => x.AgencySuperSetupId,
                        principalTable: "AgencySuperSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstTypeSetup_InstCatSetup_InstCatSetupId",
                        column: x => x.InstCatSetupId,
                        principalTable: "InstCatSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PageUrl = table.Column<string>(nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployerSupervisors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IndBaseCode = table.Column<string>(nullable: true),
                    IndBaseName = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmployerSuperSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerSupervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerSupervisors_EmployerSuperSetups_EmployerSuperSetupId",
                        column: x => x.EmployerSuperSetupId,
                        principalTable: "EmployerSuperSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseGrpSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    InstTypeId = table.Column<string>(nullable: true),
                    InstTypeSetupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGrpSetup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseGrpSetup_InstTypeSetup_InstTypeSetupId",
                        column: x => x.InstTypeSetupId,
                        principalTable: "InstTypeSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    PhoneNo1 = table.Column<string>(nullable: true),
                    PhoneNo2 = table.Column<string>(nullable: true),
                    AreaOffice = table.Column<string>(nullable: true),
                    AffiliateInst = table.Column<string>(nullable: true),
                    CapacityNo = table.Column<int>(nullable: false),
                    Deactivate = table.Column<bool>(nullable: false),
                    Datedectivated = table.Column<DateTime>(nullable: false),
                    InstTypeSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_InstTypeSetup_InstTypeSetupId",
                        column: x => x.InstTypeSetupId,
                        principalTable: "InstTypeSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: true),
                    SubMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuAccess_SubMenu_SubMenuId",
                        column: x => x.SubMenuId,
                        principalTable: "SubMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CourseGrpSetupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseGrpSetup_CourseGrpSetupId",
                        column: x => x.CourseGrpSetupId,
                        principalTable: "CourseGrpSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSetUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatricNumber = table.Column<string>(nullable: true),
                    MatricYear = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    OtherNames = table.Column<string>(nullable: true),
                    CoursesId = table.Column<int>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    YearOfStudy = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSetUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSetUps_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSetUps_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scafs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentSetUpId = table.Column<int>(nullable: false),
                    Commence_Date = table.Column<DateTime>(nullable: false),
                    Complete_Date = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    EmployerSuperSetupId = table.Column<int>(nullable: false),
                    EmployerSupervisorId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scafs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scafs_EmployerSuperSetups_EmployerSuperSetupId",
                        column: x => x.EmployerSuperSetupId,
                        principalTable: "EmployerSuperSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scafs_StudentSetUps_StudentSetUpId",
                        column: x => x.StudentSetUpId,
                        principalTable: "StudentSetUps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGrpSetup_InstTypeSetupId",
                table: "CourseGrpSetup",
                column: "InstTypeSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseGrpSetupId",
                table: "Courses",
                column: "CourseGrpSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerSuperSetups_AreaOfficeId",
                table: "EmployerSuperSetups",
                column: "AreaOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerSupervisors_EmployerSuperSetupId",
                table: "EmployerSupervisors",
                column: "EmployerSuperSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstTypeSetupId",
                table: "Institution",
                column: "InstTypeSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_InstTypeSetup_AgencySuperSetupId",
                table: "InstTypeSetup",
                column: "AgencySuperSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_InstTypeSetup_InstCatSetupId",
                table: "InstTypeSetup",
                column: "InstCatSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuAccess_SubMenuId",
                table: "MenuAccess",
                column: "SubMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Scafs_EmployerSuperSetupId",
                table: "Scafs",
                column: "EmployerSuperSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Scafs_StudentSetUpId",
                table: "Scafs",
                column: "StudentSetUpId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSetUps_CoursesId",
                table: "StudentSetUps",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSetUps_InstitutionId",
                table: "StudentSetUps",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_MenuId",
                table: "SubMenu",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployerSupervisors");

            migrationBuilder.DropTable(
                name: "InstCarryCap");

            migrationBuilder.DropTable(
                name: "InstLevelStudy");

            migrationBuilder.DropTable(
                name: "MenuAccess");

            migrationBuilder.DropTable(
                name: "PolicyTb");

            migrationBuilder.DropTable(
                name: "Scafs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SubMenu");

            migrationBuilder.DropTable(
                name: "EmployerSuperSetups");

            migrationBuilder.DropTable(
                name: "StudentSetUps");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "AreaOffices");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "CourseGrpSetup");

            migrationBuilder.DropTable(
                name: "InstTypeSetup");

            migrationBuilder.DropTable(
                name: "AgencySuperSetup");

            migrationBuilder.DropTable(
                name: "InstCatSetup");
        }
    }
}
