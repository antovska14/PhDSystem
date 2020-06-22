using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.ToTable("Faculty");
            builder.HasData(
                new Faculty() { Id = 1, Name = "Факултет за компютърни системи и технологии", DeanFullName = "проф. д-р инж. Огнян Наков", UniversityId = 1 }
            );
        }
    }
}
