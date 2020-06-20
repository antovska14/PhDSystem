using Microsoft.AspNetCore.Http;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<FileModel> ExportStudentDocument(DocumentType documentType, int studentId, int year = 0);

        Task UploadStudentFile(IFormFile file, int studentId, int year = 0);

        Task<FileModel> DownloadStudentFile(string fileName, int studentId, int year = 0);

        Task DeleteStudentFile(string fileName, int studentId, int year = 0);
    }
}
