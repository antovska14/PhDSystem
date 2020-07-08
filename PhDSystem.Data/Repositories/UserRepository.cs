using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Exceptions;
using PhDSystem.Data.Repositories.Helpers;
using PhDSystem.Data.Repositories.Interfaces;
using System;
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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CreateUser(User user)
        {
            var passwordHashed = PasswordHelper.GetHashedPassword(user, user.Password);
            user.Password = passwordHashed;

            var existingUser = GetExistingUser(user.Email);

            if (existingUser != null)
            {
                throw new AlreadyExistsException(typeof(User).Name, "email", user.Email);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task DeleteUser(int userId)
        {
            User userToDelete = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if (userToDelete == null)
            {
                throw new NotFoundException(typeof(User).Name, userId);
            }

            userToDelete.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email.ToLower().Equals(email));

            var areEqual = PasswordHelper.AreHashedAndActualPasswordsEqual(user, user.Password, password);

            if (areEqual)
            {
                return user;
            }

            return null;
        }

        // Confirm if this is used
        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<UserRole> GetUserRole(int userId)
        {
            return await (from u in _context.Users
                          join ur in _context.UserRoles on u.RoleId equals ur.Id
                          where u.Id == userId
                          select ur
                         ).FirstOrDefaultAsync();
        }

        public async Task SetPassword(int userId, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new NotFoundException(typeof(User).Name, userId);
            }

            var passwordHashed = PasswordHelper.GetHashedPassword(user, password);
            user.Password = passwordHashed;
            user.PasswordSet = true;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var currentUser = await _context.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            var existingUserWithGivenEmail = await GetExistingUser(user.Email);
            if (existingUserWithGivenEmail.Id != currentUser.Id)
            {
                throw new AlreadyExistsException(typeof(User).Name, "email", user.Email);
            }

            currentUser.Email = user.Email;
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetExistingUser(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
