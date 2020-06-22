using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;

namespace PhDSystem.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasData(
                new User() { Id = 1, Email = "admin@gmail.com", Password = "admin", RoleId = 1 },
                new User() { Id = 2, Email = "student@gmail.com", Password = "student", RoleId = 2 },
                new User() { Id = 3, Email = "supervisor@gmail.com", Password = "supervisor", RoleId = 3 }
            );
        }
    }
}
