﻿using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentFileRepository
    {
        Task CreateStudentFileRecord(int studentId, string fileGroup, string fileName);

        Task DeleteStudentFileRecord(int studentId, string fileGroup, string fileName);

        Task<IEnumerable<StudentFileGroupDetails>> GetStudentFileDetailsList(int studentId);

        Task<bool> FileExists(int studentId, string fileGroup, string fileName);
    }
}
