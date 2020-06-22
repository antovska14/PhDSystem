using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CurrentYear", "DepartmentId", "DisertationTheme", "EndDate", "FacultyCouncilChosenDate", "FirstName", "FormOfEducationId", "IsDeleted", "LastName", "MiddleName", "PhdProgramId", "SpecialtyName", "StartDate", "UserId" },
                values: new object[] { 1, 0, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Local), "Dijana", 1, false, "Antovska", null, 1, "Computer and Software Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
