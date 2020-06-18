using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class UpdateFormOfEducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "редовна");

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "задочна");

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "свободна");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "FullTime");

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Distance");

            migrationBuilder.UpdateData(
                table: "FormOfEducation",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Free");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
