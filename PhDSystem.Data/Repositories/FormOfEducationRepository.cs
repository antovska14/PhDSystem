using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class FormOfEducationRepository : IFormOfEducationRepository
    {
        private readonly PhdSystemDbContext _context;

        public FormOfEducationRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<FormOfEducation>> GetFormsOfEducation()
        {
            return await _context.FormsOfEducation.ToListAsync();
        }
    }
}
