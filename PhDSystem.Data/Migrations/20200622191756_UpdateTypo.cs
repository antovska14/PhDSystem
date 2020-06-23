using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class UpdateTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisertationTheme",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "DissertationTheme",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DissertationTheme",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "DisertationTheme",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
