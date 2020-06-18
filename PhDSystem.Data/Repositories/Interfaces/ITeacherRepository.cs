using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task CreateTeacherAsync(TeacherDetails teacherDetails);
        Task DeleteTeacherAsync(int teacherId);
        Task<TeacherDetails> GetTeacherAsync(int teacherId);
        Task<IEnumerable<TeacherDetails>> GetTeachersAsync();
        Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails);
    }
}
