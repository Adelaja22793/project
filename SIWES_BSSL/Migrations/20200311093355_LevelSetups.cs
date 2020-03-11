using Microsoft.EntityFrameworkCore.Migrations;

namespace SIWES_BSSL.Migrations
{
    public partial class LevelSetups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy");

            migrationBuilder.AlterColumn<int>(
                name: "InstTypeSetupId",
                table: "InstLevelStudy",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy",
                column: "InstTypeSetupId",
                principalTable: "InstTypeSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy");

            migrationBuilder.AlterColumn<int>(
                name: "InstTypeSetupId",
                table: "InstLevelStudy",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy",
                column: "InstTypeSetupId",
                principalTable: "InstTypeSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
