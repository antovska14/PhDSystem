using Microsoft.EntityFrameworkCore;
using PhDSystem.Core.Interfaces.Data.Repositories;
using PhDSystem.Core.DTOs;
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