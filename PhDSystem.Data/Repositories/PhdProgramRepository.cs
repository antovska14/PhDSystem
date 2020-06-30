using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class PhdProgramRepository : IPhdProgramRepository
    {
        private readonly PhdSystemDbContext _context;

        public PhdProgramRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddPhdProgram(PhdProgram phdProgram)
        {
            _context.Add(phdProgram);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhdProgram(int phdProgramId)
        {
            var phdProgram = await _context.PhdPrograms.Where(p => p.Id.Equals(phdProgramId)).SingleOrDefaultAsync();
            _context.Remove(phdProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhdProgram>> GetPhdPrograms(int professionalField)
        {
            var phdPrograms = await _context.PhdPrograms.Where(p => p.ProfessionalFieldId == professionalField).ToListAsync();

            return phdPrograms;
        }

        public async Task<IEnumerable<PhdProgram>> GetPhdPrograms()
        {
            var phdPrograms = await (from pp in _context.PhdPrograms
                                     join pf in _context.ProfessionalFields on pp.ProfessionalFieldId equals pf.Id
                                     select new PhdProgram
                                     {
                                         Id = pp.Id,
                                         ProfessionalFieldId = pp.ProfessionalFieldId,
                                         Name = pp.Name,
                                         ProfessionalField = new ProfessionalField
                                         {
                                             Id = pf.Id,
                                             Name = pf.Name
                                         }
                                     }).ToListAsync();

            return phdPrograms;
        }
    }
}
