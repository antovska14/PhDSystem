using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class ProfessionalFieldConfiguration : IEntityTypeConfiguration<ProfessionalField>
    {
        public void Configure(EntityTypeBuilder<ProfessionalField> builder)
        {
            builder.ToTable("ProfessionalField");
            builder.HasData(
                new ProfessionalField() { Id = 1, Name = "Комуникационна и компютърна техника" }
            );
        }
    }
}
