using Microsoft.EntityFrameworkCore.Migrations;

namespace SIWES_BSSL.Data.Migrations
{
    public partial class updateinst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institution_InstCatSetup_InstCatSetupId1",
                table: "Institution");

            migrationBuilder.DropForeignKey(
                name: "FK_Institution_InstTypeSetup_InstTypeSetupId1",
                table: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Institution_InstCatSetupId1",
                table: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Institution_InstTypeSetupId1",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "InstCatSetupId",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "InstCatSetupId1",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "InstTypeSetupId1",
                table: "Institution");

            migrationBuilder.AlterColumn<int>(
                name: "InstTypeSetupId",
                table: "Institution",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstTypeSetupId",
                table: "Institution",
                column: "InstTypeSetupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institution_InstTypeSetup_InstTypeSetupId",
                table: "Institution",
                column: "InstTypeSetupId",
                principalTable: "InstTypeSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institution_InstTypeSetup_InstTypeSetupId",
                table: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_Institution_InstTypeSetupId",
                table: "Institution");

            migrationBuilder.AlterColumn<string>(
                name: "InstTypeSetupId",
                table: "Institution",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "InstCatSetupId",
                table: "Institution",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstCatSetupId1",
                table: "Institution",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstTypeSetupId1",
                table: "Institution",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstCatSetupId1",
                table: "Institution",
                column: "InstCatSetupId1");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstTypeSetupId1",
                table: "Institution",
                column: "InstTypeSetupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Institution_InstCatSetup_InstCatSetupId1",
                table: "Institution",
                column: "InstCatSetupId1",
                principalTable: "InstCatSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institution_InstTypeSetup_InstTypeSetupId1",
                table: "Institution",
                column: "InstTypeSetupId1",
                principalTable: "InstTypeSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
