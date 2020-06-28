using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;
using System;

namespace PhDSystem.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasData(
                new Student() { Id = 1, FirstName = "Dijana", LastName = "Antovska", UserId = 2, FormOfEducationId = 1, SpecialtyName = "Computer and Software Engineering", FacultyCouncilChosenDate = DateTime.Now.Date, PhdProgramId = 1, DepartmentId = 1, DissertationTheme="Talking Robot" }
            );
        }
    }
}
