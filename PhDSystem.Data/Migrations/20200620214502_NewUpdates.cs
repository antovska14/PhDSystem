using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class NewUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    FileGroup = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFiles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentFiles");

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1,
                column: "FacultyCouncilChosenDate",
                value: new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
