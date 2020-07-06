using PhDSystem.Api.Models;
using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuth> ValidateUserAsync(User user);
    }
}
