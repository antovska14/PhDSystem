using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userName, string password);
        Task<UserRole> GetUserRole(int userId);
    }
}
