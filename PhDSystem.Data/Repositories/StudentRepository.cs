using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.POCOs;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PhdSystemContext _context;

        public StudentRepository(PhdSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}