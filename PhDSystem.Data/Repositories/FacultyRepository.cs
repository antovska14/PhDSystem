using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly PhdSystemDbContext _context;

        public FacultyRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Faculty>> GetFaculties(int universityId)
        {
            return await _context.Faculties.Where(f => f.UniversityId == universityId).ToListAsync();
        }
    }
}
