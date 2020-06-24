using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasData(
                new UserRole() { Id = 1, Name = "Admin" },
                new UserRole() { Id = 2, Name = "Student" },
                new UserRole() { Id = 3, Name = "Teacher" }
            );
        }
    }
}
