using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class FormOfEducationConfiguration : IEntityTypeConfiguration<FormOfEducation>
    {
        public void Configure(EntityTypeBuilder<FormOfEducation> builder)
        {
            builder.ToTable("FormOfEducation");
            builder.HasData(
                new FormOfEducation() { Id = 1, Name = "редовна", YearsCount = 3 },
                new FormOfEducation() { Id = 2, Name = "задочна", YearsCount = 4 },
                new FormOfEducation() { Id = 3, Name = "свободна", YearsCount = 3 }
            );
        }
    }
}
