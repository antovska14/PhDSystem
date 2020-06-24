using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IUniversityRepository
    {
        Task<IEnumerable<University>> GetUniversities();
    }
}
