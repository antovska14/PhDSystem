using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Interfaces;
using PhDSystem.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data
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