using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task<Student> GetStudentAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsBySupervisorAsync(int supervisorId);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task UpdateStudentAsync(int studentId, Student student);
    }
}
