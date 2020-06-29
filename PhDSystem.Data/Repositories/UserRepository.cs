using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PhdSystemDbContext _context;

        public UserRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            var hasher = new PasswordHasher<User>();
            var passwordHashed = hasher.HashPassword(user, user.Password);
            user.Password = passwordHashed;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task DeleteUser(int userId)
        {
            User userToDelete = await _context.Users.Where(u => u.Id == userId).SingleOrDefaultAsync();
            userToDelete.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email, string password)
        {
            var user = await _context.Users
                                 .Where(u => u.Email.ToLower().Equals(email))
                                 .SingleOrDefaultAsync();

            var hasher = new PasswordHasher<User>();
            var passwordHashed = hasher.HashPassword(user, user.Password);
            var verificationResult = hasher.VerifyHashedPassword(user, passwordHashed, user.Password);

            if (verificationResult == PasswordVerificationResult.Success 
                || verificationResult == PasswordVerificationResult.SuccessRehashNeeded)
            {
                return user;
            }

            return null;
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users
                                 .Where(u => u.Id == userId)
                                 .FirstOrDefaultAsync();
        }

        public async Task<UserRole> GetUserRole(int userId)
        {
            return await (from u in _context.Users 
                         join ur in _context.UserRoles on u.RoleId equals ur.Id
                         where u.Id == userId
                         select ur     
                         ).FirstOrDefaultAsync();
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _context.Users.Where(u => u.Id == user.Id).SingleOrDefaultAsync();
            existingUser.Email = user.Email;
        }
    }
}
