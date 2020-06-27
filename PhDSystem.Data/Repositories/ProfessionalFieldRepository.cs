using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
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
            _context = context;
        }

        public async Task AddProfessionalField(ProfessionalField professionalField)
        {
            _context.ProfessionalFields.Add(professionalField);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProfessionalField(int professionalFieldId)
        {
            var professionalField = await _context.ProfessionalFields.Where(p => p.Id.Equals(professionalFieldId)).SingleOrDefaultAsync();
            _context.Remove(professionalField);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProfessionalField>> GetProfessionalFields()
        {
            return await _context.ProfessionalFields.ToListAsync();
        }
    }
}
