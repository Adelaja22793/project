using Microsoft.EntityFrameworkCore.Migrations;

namespace SIWES_BSSL.Migrations
{
    public partial class LevelSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstTypeSetupId",
                table: "InstLevelStudy",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstLevelStudy_InstTypeSetupId",
                table: "InstLevelStudy",
                column: "InstTypeSetupId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy",
                column: "InstTypeSetupId",
                principalTable: "InstTypeSetup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstLevelStudy_InstTypeSetup_InstTypeSetupId",
                table: "InstLevelStudy");

            migrationBuilder.DropIndex(
                name: "IX_InstLevelStudy_InstTypeSetupId",
                table: "InstLevelStudy");

            migrationBuilder.DropColumn(
                name: "InstTypeSetupId",
                table: "InstLevelStudy");
        }
    }
}
