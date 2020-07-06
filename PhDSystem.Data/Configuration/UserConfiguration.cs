using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Helpers;

namespace PhDSystem.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User() { Id = 1, Email = "admin@gmail.com", RoleId = 1 };
            var password = PasswordHelper.GetHashedPassword(user, "admin");
            user.Password = password;
            builder.ToTable("User");
            builder.HasData(user);
        }
    }
}
