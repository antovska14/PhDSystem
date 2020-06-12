using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserClaim>> GetUserClaims(int userId);

        Task<User> GetUser(string userName, string password);
    }
}
