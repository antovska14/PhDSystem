using PhDSystem.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Interfaces
{
    public interface IStudentData
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
