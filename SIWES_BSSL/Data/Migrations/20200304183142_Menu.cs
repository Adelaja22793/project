using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SIWES_BSSL.Data.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "InstCarryCap");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "InstLevelStudy");

            migrationBuilder.DropTable(
                name: "MenuAccess");

            migrationBuilder.DropTable(
                name: "PolicyTb");

            migrationBuilder.DropTable(
                name: "CourseGrpSetup");

            migrationBuilder.DropTable(
                name: "InstTypeSetup");

            migrationBuilder.DropTable(
                name: "AgencySuperSetup");

            migrationBuilder.DropTable(
                name: "InstCatSetup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencySuperSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    CPersonEmail = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    DeactDate = table.Column<DateTime>(nullable: false),
                    Deactivate = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameOfCPerson = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencySuperSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstCarryCap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowDisporal = table.Column<bool>(nullable: false),
                    DelistInst = table.Column<bool>(nullable: false),
                    InstypeId = table.Column<string>(nullable: true),
                    MasterListDate = table.Column<DateTime>(nullable: false),
                    MaxSiwesCap = table.Column<int>(nullable: false),
                    MinVisit4Super = table.Column<int>(nullable: false),
                    MustNotExcCap = table.Column<bool>(nullable: false),
                    StudentAmt = table.Column<decimal>(nullable: false),
                    SuperAmt = table.Column<decimal>(nullable: false)
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
                    Duration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstLevelStudy", x => x.Id);
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
                name: "PolicyTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowDisporal = table.Column<bool>(nullable: false),
                    DelistInst = table.Column<bool>(nullable: false),
                    InstypeId = table.Column<string>(nullable: true),
                    MasterListDate = table.Column<DateTime>(nullable: false),
                    MaxSiwesCap = table.Column<int>(nullable: false),
                    MinVisit4Super = table.Column<int>(nullable: false),
                    MustNotExcCap = table.Column<bool>(nullable: false),
                    StudentAmt = table.Column<decimal>(nullable: false),
                    SuperAmt = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstTypeSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgencySuperSetupId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    InstCatSetupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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
                name: "CourseGrpSetup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    InstTypeId = table.Column<string>(nullable: true),
                    InstTypeSetupId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true)
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
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    AffiliateInst = table.Column<string>(nullable: true),
                    AreaOffice = table.Column<string>(nullable: true),
                    CapacityNo = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Datedectivated = table.Column<DateTime>(nullable: false),
                    Deactivate = table.Column<bool>(nullable: false),
                    InstCatSetupId = table.Column<string>(nullable: true),
                    InstCatSetupId1 = table.Column<int>(nullable: true),
                    InstTypeSetupId = table.Column<string>(nullable: true),
                    InstTypeSetupId1 = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNo1 = table.Column<string>(nullable: true),
                    PhoneNo2 = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institution_InstCatSetup_InstCatSetupId1",
                        column: x => x.InstCatSetupId1,
                        principalTable: "InstCatSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Institution_InstTypeSetup_InstTypeSetupId1",
                        column: x => x.InstTypeSetupId1,
                        principalTable: "InstTypeSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CourseGrpSetupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_CourseGrpSetup_InstTypeSetupId",
                table: "CourseGrpSetup",
                column: "InstTypeSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseGrpSetupId",
                table: "Courses",
                column: "CourseGrpSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstCatSetupId1",
                table: "Institution",
                column: "InstCatSetupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstTypeSetupId1",
                table: "Institution",
                column: "InstTypeSetupId1");

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
        }
    }
}
