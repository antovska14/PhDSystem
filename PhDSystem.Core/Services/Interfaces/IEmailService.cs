using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IEmailService
    {
        Task NotifyUserForInitialCredentials(string email, string password);
    }
}
