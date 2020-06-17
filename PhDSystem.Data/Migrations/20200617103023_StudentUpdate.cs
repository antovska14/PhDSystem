using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class StudentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentYear",
                schema: "dbo",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "FullTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentYear",
                schema: "dbo",
                table: "Student");

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Regular");
        }
    }
}
