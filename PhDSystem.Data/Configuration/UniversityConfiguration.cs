using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhDSystem.Data.Configuration
{
    public class UniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> builder)
        {
            builder.ToTable("University");
            builder.HasData(
                new University() { Id = 1, Name = "Технически Университет - София", RectorFullName = "проф. дтн инж. Иван Кралов" }
            );
        }
    }
}
