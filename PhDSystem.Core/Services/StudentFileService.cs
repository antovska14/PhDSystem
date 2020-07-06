using Microsoft.AspNetCore.Http;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services
{
    public class StudentFileService : IStudentFileService
    {
        private readonly IStudentFileRepository _studentFileRepository;
        private readonly IFileManager _fileManager;

        public StudentFileService(IStudentFileRepository studentFileRepository, IFileManager fileManager)
        {
            _studentFileRepository = studentFileRepository;
            _fileManager = fileManager;
        }

        public async Task DeleteStudentFile(string fileName, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);
            string[] folders = new string[] { FileConstants.UserFilesFolder, studentId.ToString(), fileGroup };

            _fileManager.DeleteFile(folders, fileName);

            await _studentFileRepository.DeleteStudentFileRecord(studentId, fileGroup, fileName);
        }

        public async Task<FileModel> DownloadStudentFile(string fileName, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);
            string[] folders = new string[] { FileConstants.UserFilesFolder, studentId.ToString(), fileGroup };

            var resultFile = await _fileManager.GetFileAsync(folders, fileName);

            return resultFile;
        }

        public async Task<IEnumerable<StudentFileGroupDetails>> GetStudentFileDetailsList(int studentId)
        {
            return await _studentFileRepository.GetStudentFileDetailsList(studentId);
        }

        public async Task UploadStudentFile(IFormFile file, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);
            string[] folders = new string[] { FileConstants.UserFilesFolder, studentId.ToString(), fileGroup };

            await _fileManager.StoreFileAsync(folders, file);

            await _studentFileRepository.CreateStudentFileRecord(studentId, fileGroup, file.FileName);
        }

        private string GetFileGroup(int year)
        {
            return year != 0 ? year.ToString() : FileConstants.GeneralFolder;
        }
    }
}
