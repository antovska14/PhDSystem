using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PhdSystemContext _context;

        public UserRepository(PhdSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaims(int userId)
        {
            return await _context.UserClaims.Where(uc => uc.UserId == userId).ToListAsync();
        }

        public async Task<User> GetUser(string userName, string password)
        {
            return await _context.Users
                                 .Where(u => u.UserName.ToLower().Equals(userName) && u.Password.Equals(password))
                                 .FirstOrDefaultAsync();
        }
    }
}
