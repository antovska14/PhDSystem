using PhDSystem.Api.Models;
using System.Threading.Tasks;

namespace PhDSystem.Api.Managers.Interfaces
{
    public interface IFileManager
    {
        Task<FileModel> GetFileAsync(string bucketName, string folderName, string fileName);
    }
}
