using PhDSystem.Data.Models.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentDetails studentCreateData);
        Task<IEnumerable<StudentListModel>> GetStudentsByTeacherUserIdAsync(int teacherUserId);
        Task UpdateStudentAsync(int studentId, StudentDetails studentUpdateData);
    }
}
