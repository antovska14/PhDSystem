using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "FormOfEducation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    YearsCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormOfEducation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalField",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    FormOfEducationId = table.Column<int>(nullable: false),
                    SpecialtyName = table.Column<string>(maxLength: 255, nullable: false),
                    FacultyCouncilChosenDate = table.Column<DateTime>(nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_FormOfEducation_FormOfEducationId",
                        column: x => x.FormOfEducationId,
                        principalTable: "FormOfEducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhdProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ProfessionalFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhdProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhdProgram_ProfessionalField_ProfessionalFieldId",
                        column: x => x.ProfessionalFieldId,
                        principalTable: "ProfessionalField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormOfEducation",
                columns: new[] { "Id", "Name", "YearsCount" },
                values: new object[,]
                {
                    { 1, "Regular", 3 },
                    { 2, "Distance", 4 },
                    { 3, "Free", 3 }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "MiddleName", "UserId" },
                values: new object[] { 1, "Bill", false, "Gates", null, 3 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Student" },
                    { 3, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "IsDeleted", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, false, "admin", 1, "admin" },
                    { 2, false, "student", 2, "student" },
                    { 3, false, "supervisor", 3, "supervisor" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Student",
                columns: new[] { "Id", "DegreeId", "FacultyCouncilChosenDate", "FirstName", "FormOfEducationId", "IsDeleted", "LastName", "MiddleName", "SpecialtyName", "TitleId", "UserId" },
                values: new object[] { 1, 0, new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), "Dijana", 1, false, "Antovska", null, "Computer and Software Engineering", 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PhdProgram_ProfessionalFieldId",
                table: "PhdProgram",
                column: "ProfessionalFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeacherId",
                table: "StudentTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FormOfEducationId",
                schema: "dbo",
                table: "Student",
                column: "FormOfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                schema: "dbo",
                table: "Student",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhdProgram");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ProfessionalField");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "FormOfEducation");
        }
    }
}
