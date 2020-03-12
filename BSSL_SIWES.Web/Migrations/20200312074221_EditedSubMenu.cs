using Microsoft.EntityFrameworkCore.Migrations;

namespace BSSL_SIWES.Web.Migrations
{
    public partial class EditedSubMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubId",
                table: "SubMenu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubId",
                table: "SubMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
