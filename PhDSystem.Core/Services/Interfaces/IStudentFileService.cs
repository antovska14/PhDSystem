﻿using Microsoft.AspNetCore.Http;
using PhDSystem.Core.Models;
using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IStudentFileService
    {
        Task UploadStudentFile(IFormFile file, int studentId, int year = 0);

        Task<FileModel> DownloadStudentFile(string fileName, int studentId, int year = 0);

        Task DeleteStudentFile(string fileName, int studentId, int year = 0);

        Task<IEnumerable<StudentFileGroupDetails>> GetStudentFileDetailsList(int studentId);
    }
}
