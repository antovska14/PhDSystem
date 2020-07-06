using PhDSystem.Data.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task CreateStudentAsync(StudentDetails studentCreateData);
        Task DeleteStudentAsync(int studentId);
        Task<StudentDetails> GetStudentAsync(int studentId);
        Task<int> GetStudentIdAsync(int userId);
        Task<IEnumerable<StudentListModel>> GetStudentsByTeacherAsync(int teacherId);
        Task<IEnumerable<StudentListModel>> GetStudentsAsync();
        Task UpdateStudentAsync(int studentId, StudentDetails studentUpdateData);
    }
}
