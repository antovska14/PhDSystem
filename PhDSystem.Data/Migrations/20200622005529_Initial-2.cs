using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "DeanFullName", "Name", "UniversityId" },
                values: new object[] { 1, "проф. д-р инж. Огнян Наков", "Факултет за компютърни системи и технологии", 1 });

            migrationBuilder.InsertData(
                table: "PhdProgram",
                columns: new[] { "Id", "Name", "ProfessionalFieldId" },
                values: new object[] { 1, "Системи с изкуствен интелект", 1 });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Degree", "FirstName", "IsDeleted", "LastName", "MiddleName", "Title", "UserId" },
                values: new object[] { 1, null, "Bill", false, "Gates", null, null, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhdProgram",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teacher",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
