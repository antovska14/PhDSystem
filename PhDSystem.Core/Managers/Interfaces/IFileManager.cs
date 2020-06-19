using Microsoft.AspNetCore.Http;
using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Managers.Interfaces
{
    public interface IFileManager
    {
        Task<FileModel> GetFileAsync(string[] folders, string fileName);

        Task StoreFileAsync(string[] folders, IFormFile fileName);
    }
}
