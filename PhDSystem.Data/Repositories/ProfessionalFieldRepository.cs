using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Exceptions;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class ProfessionalFieldRepository : IProfessionalFieldRepository
    {
        private readonly PhdSystemDbContext _context;

        public ProfessionalFieldRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddProfessionalField(ProfessionalField professionalField)
        {
            var existingProfessionalField = await _context.ProfessionalFields.Where(pf => pf.Name.Equals(professionalField.Name))
                                                                             .SingleOrDefaultAsync();

            if (existingProfessionalField != null)
            {
                throw new AlreadyExistsException(typeof(ProfessionalField).Name, "name", existingProfessionalField.Name);
            }

            _context.ProfessionalFields.Add(professionalField);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessionalField(int professionalFieldId)
        {
            var professionalField = await _context.ProfessionalFields.Where(p => p.Id.Equals(professionalFieldId)).SingleOrDefaultAsync();

            if (professionalField == null)
            {
                throw new NotFoundException(typeof(ProfessionalField).Name, professionalFieldId);
            }

            _context.Remove(professionalField);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProfessionalField>> GetProfessionalFields()
        {
            return await _context.ProfessionalFields.ToListAsync();
        }
    }
}
