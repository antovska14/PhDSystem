using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(TeacherDetails teacherDetails);
        Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails);
    }
}
