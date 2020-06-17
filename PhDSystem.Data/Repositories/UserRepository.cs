using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            return await _context.Users
                                 .Where(u => u.Email.ToLower().Equals(email) && u.Password.Equals(password))
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
