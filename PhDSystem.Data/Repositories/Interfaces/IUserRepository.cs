using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> CreateUser(User user);
        Task DeleteUser(int userId);
        Task<User> GetUser(string email, string password);
        Task<User> GetUser(int userId);
        Task<UserRole> GetUserRole(int userId);
        Task SetPassword(int userId, string password);
        Task UpdateUser(User user);
    }
}
