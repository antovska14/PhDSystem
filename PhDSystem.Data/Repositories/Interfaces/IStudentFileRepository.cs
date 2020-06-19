using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentFileRepository
    {
        Task CreateStudentFileRecord(int studentId, string fileGroup, string fileName);
    }
}
