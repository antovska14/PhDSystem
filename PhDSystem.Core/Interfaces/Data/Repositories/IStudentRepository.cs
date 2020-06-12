using PhDSystem.Core.POCOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Interfaces.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
    }
}
