using PhDSystem.Core.Services.Models;
using PhDSystem.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentDetails studentDetails);
        Task DeleteStudentAsync(int studentId);
        Task<StudentDetails> GetStudentAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsBySupervisorAsync(int supervisorId);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task UpdateStudentAsync(int studentId, StudentDetails studentDetails);
    }
}
