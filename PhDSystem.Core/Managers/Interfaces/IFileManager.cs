using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Managers.Interfaces
{
    public interface IFileManager
    {
        Task<FileModel> GetFileAsync(string bucketName, string folderName, string fileName);
    }
}
