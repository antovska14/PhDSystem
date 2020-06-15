using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class AddStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Student",
                columns: new[] { "Id", "DegreeId", "FirstName", "FormOfEducationId", "IsDeleted", "LastName", "MiddleName", "TitleId", "UserId" },
                values: new object[] { 1, 0, "Dijana", 0, false, "Antovska", null, 0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
