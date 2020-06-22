using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasData(
                new Department() { Id = 1, Name = "Компютърни системи", HeadFullName = "проф. д-р инж. Милена Лазарова", FacultyId = 1 }
            );
        }
    }
}
