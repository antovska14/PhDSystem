using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhDSystem.Data.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    RectorFullName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
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
                name: "PhdProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
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
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    DeanFullName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculty_University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false),
                    PasswordSet = table.Column<bool>(nullable: false),
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
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    HeadFullName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Title = table.Column<string>(maxLength: 255, nullable: true),
                    Degree = table.Column<string>(maxLength: 255, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    FormOfEducationId = table.Column<int>(nullable: false),
                    PhdProgramId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    CurrentYear = table.Column<int>(nullable: false),
                    SpecialtyName = table.Column<string>(maxLength: 255, nullable: false),
                    DissertationTheme = table.Column<string>(maxLength: 255, nullable: false),
                    FacultyCouncilChosenDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_FormOfEducation_FormOfEducationId",
                        column: x => x.FormOfEducationId,
                        principalTable: "FormOfEducation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_PhdProgram_PhdProgramId",
                        column: x => x.PhdProgramId,
                        principalTable: "PhdProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Grade = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    FileGroup = table.Column<string>(maxLength: 255, nullable: false),
                    FileName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentFiles_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
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
                        principalTable: "Student",
                        principalColumn: "Id");
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
                    { 1, "редовна", 3 },
                    { 2, "задочна", 4 },
                    { 3, "свободна", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProfessionalField",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Комуникационна и компютърна техника" });

            migrationBuilder.InsertData(
                table: "University",
                columns: new[] { "Id", "Name", "RectorFullName" },
                values: new object[] { 1, "Технически Университет - София", "проф. дтн инж. Иван Кралов" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Student" },
                    { 3, "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "DeanFullName", "Name", "UniversityId" },
                values: new object[] { 1, "проф. д-р инж. Огнян Наков", "Факултет за компютърни системи и технологии", 1 });

            migrationBuilder.InsertData(
                table: "PhdProgram",
                columns: new[] { "Id", "Name", "ProfessionalFieldId" },
                values: new object[] { 1, "Системи с изкуствен интелект", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "IsDeleted", "Password", "PasswordSet", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", false, "admin", false, 1 },
                    { 2, "student@gmail.com", false, "student", false, 2 },
                    { 3, "teacher@gmail.com", false, "teacher", false, 3 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "FacultyId", "HeadFullName", "Name" },
                values: new object[] { 1, 1, "проф. д-р инж. Милена Лазарова", "Компютърни системи" });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "Id", "Degree", "FirstName", "IsDeleted", "LastName", "MiddleName", "Title", "UserId" },
                values: new object[] { 1, null, "Bill", false, "Gates", null, null, 3 });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CurrentYear", "DepartmentId", "DissertationTheme", "EndDate", "FacultyCouncilChosenDate", "FirstName", "FormOfEducationId", "IsDeleted", "LastName", "MiddleName", "PhdProgramId", "SpecialtyName", "StartDate", "UserId" },
                values: new object[] { 1, 0, 1, "Talking Robot", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), "Dijana", 1, false, "Antovska", null, 1, "Computer and Software Engineering", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentId",
                table: "Exam",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UniversityId",
                table: "Faculty",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_PhdProgram_ProfessionalFieldId",
                table: "PhdProgram",
                column: "ProfessionalFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DepartmentId",
                table: "Student",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FormOfEducationId",
                table: "Student",
                column: "FormOfEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PhdProgramId",
                table: "Student",
                column: "PhdProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentFiles_StudentId",
                table: "StudentFiles",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeacherId",
                table: "StudentTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserId",
                table: "Teacher",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "StudentFiles");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "FormOfEducation");

            migrationBuilder.DropTable(
                name: "PhdProgram");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "ProfessionalField");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
