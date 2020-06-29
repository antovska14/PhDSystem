using PhDSystem.Core.Models;
using PhDSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuth> ValidateUserAsync(User user);
        Task SetPassword(SetPasswordModel setPasswordModel);
    }
}
