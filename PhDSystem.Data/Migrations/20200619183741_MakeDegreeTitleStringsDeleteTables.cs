using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class MakeDegreeTitleStringsDeleteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Teacher",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Teacher");

            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
