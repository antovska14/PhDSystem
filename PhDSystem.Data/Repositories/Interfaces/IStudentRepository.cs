using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudent(int studentId);
        Task<IEnumerable<Student>> GetSupervisorStudents(int supervisorId);
        Task<IEnumerable<Student>> GetStudents();
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
    }
}
