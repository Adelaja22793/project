using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BSSL_SIWES.Web.Migrations
{
    public partial class Added_IntitutionTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstitutionOfficers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deactivate = table.Column<bool>(nullable: false),
                    DateActivated = table.Column<DateTime>(nullable: false),
                    InstitutionId = table.Column<int>(nullable: false),
                    OfficerType = table.Column<string>(nullable: true),
                    StaffId = table.Column<string>(nullable: true),
                    IntOfficerName = table.Column<string>(nullable: true),
                    IntOfficerDesig = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    StatesId = table.Column<int>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    SwitchCode = table.Column<string>(nullable: true),
                    NumberOfStudent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionOfficers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionOfficers_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionOfficers_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstitutionOfficers_States_StatesId",
                        column: x => x.StatesId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupervisoryAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deactivate = table.Column<bool>(nullable: false),
                    DateActivated = table.Column<DateTime>(nullable: false),
                    AgencySuperSetupId = table.Column<int>(nullable: false),
                    StaffId = table.Column<string>(nullable: true),
                    AgencyOfficerName = table.Column<string>(nullable: true),
                    AgencyOfficerDesig = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    StatesId = table.Column<int>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisoryAgencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupervisoryAgencies_AgencySuperSetup_AgencySuperSetupId",
                        column: x => x.AgencySuperSetupId,
                        principalTable: "AgencySuperSetup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisoryAgencies_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupervisoryAgencies_States_StatesId",
                        column: x => x.StatesId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewCourseRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InstitiutionOfficerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewCourseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewCourseRequests_InstitutionOfficers_InstitiutionOfficerId",
                        column: x => x.InstitiutionOfficerId,
                        principalTable: "InstitutionOfficers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionOfficers_InstitutionId",
                table: "InstitutionOfficers",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionOfficers_NationalityId",
                table: "InstitutionOfficers",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionOfficers_StatesId",
                table: "InstitutionOfficers",
                column: "StatesId");

            migrationBuilder.CreateIndex(
                name: "IX_NewCourseRequests_InstitiutionOfficerId",
                table: "NewCourseRequests",
                column: "InstitiutionOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoryAgencies_AgencySuperSetupId",
                table: "SupervisoryAgencies",
                column: "AgencySuperSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoryAgencies_NationalityId",
                table: "SupervisoryAgencies",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisoryAgencies_StatesId",
                table: "SupervisoryAgencies",
                column: "StatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewCourseRequests");

            migrationBuilder.DropTable(
                name: "SupervisoryAgencies");

            migrationBuilder.DropTable(
                name: "InstitutionOfficers");
        }
    }
}
