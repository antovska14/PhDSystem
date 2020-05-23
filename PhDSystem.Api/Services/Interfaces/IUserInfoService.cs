using PhDSystem.Api.Models;

namespace PhDSystem.Api.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo Authenticate(string username, string password);
    }
}
