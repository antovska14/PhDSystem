using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class RenameContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
