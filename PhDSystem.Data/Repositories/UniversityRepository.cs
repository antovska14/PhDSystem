using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly PhdSystemDbContext _context;

        public UniversityRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<University>> GetUniversities()
        {
            return await _context.Universities.ToListAsync();
        }
    }
}
