using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class PhdProgramConfiguration : IEntityTypeConfiguration<PhdProgram>
    {
        public void Configure(EntityTypeBuilder<PhdProgram> builder)
        {
            builder.ToTable("PhdProgram");
            builder.HasData(
                new PhdProgram() { Id = 1, Name = "Системи с изкуствен интелект", ProfessionalFieldId = 1 }
            );
        }
    }
}
