using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");
            builder.HasData(
                new Teacher() { Id = 1, FirstName = "Bill", LastName = "Gates", UserId = 3 }
            );
        }
    }
}
