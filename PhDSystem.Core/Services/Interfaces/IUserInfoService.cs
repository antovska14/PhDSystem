
using PhDSystem.Core.Models;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string username, string password);
    }
}
