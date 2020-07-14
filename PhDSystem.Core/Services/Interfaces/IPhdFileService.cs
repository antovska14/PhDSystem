using PhDSystem.Core.Enums;
using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IPhdFileService
    {
        Task<FileModel> ExportStudentFileAsync(PhdFileType documentType, int studentId, int year = 0);
    }
}
