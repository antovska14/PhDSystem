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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPCb6UYWH97DVv3ugQB8yH4+v8uMp4Lw6wkcMyherftN4SlKp9B28/FsiP1auu7qhg==");
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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAECQkXBg+F320VVzKKV2kHJJAMDSCmCmqt8Q8GKLiiXgde9ylfwSj8GvlazZWxOZ3ew==");
        }
    }
}
