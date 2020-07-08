using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PhdSystemDbContext _context;

        public DepartmentRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Department>> GetDepartments(int facultyId)
        {
            return await _context.Departments.Where(d => d.FacultyId == facultyId).ToListAsync();
        }
    }
}
