using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "FacultyId", "HeadFullName", "Name" },
                values: new object[] { 1, 1, "проф. д-р инж. Милена Лазарова", "Компютърни системи" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEOA6ME66aHTylm29p9fsv+tPUhXFBed4QCOsygPhdUBhrNsr53hd+IIBopWzoNR04Q==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "AQAAAAEAACcQAAAAEPCb6UYWH97DVv3ugQB8yH4+v8uMp4Lw6wkcMyherftN4SlKp9B28/FsiP1auu7qhg==");
        }
    }
}
