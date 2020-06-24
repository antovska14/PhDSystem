using PhDSystem.Data.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentUpsertModel studentCreateData);
        Task DeleteStudentAsync(int studentId);
        Task<StudentDetails> GetStudentAsync(int studentId);
        Task<IEnumerable<StudentListModel>> GetStudentsByTeacherUserIdAsync(int teacherUserId);
        Task<IEnumerable<StudentListModel>> GetStudentsAsync();
        Task UpdateStudentAsync(int studentId, StudentUpsertModel studentUpdateData);
    }
}
