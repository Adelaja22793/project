using Microsoft.EntityFrameworkCore.Migrations;

namespace BSSL_SIWES.Web.Migrations
{
    public partial class EditedMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Namecode",
                table: "Menu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Namecode",
                table: "Menu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
