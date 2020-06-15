using PhDSystem.Core.Models;
using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuth> ValidateUserAsync(User user);
    }
}
