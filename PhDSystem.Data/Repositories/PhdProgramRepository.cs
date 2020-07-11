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
    public class PhdProgramRepository : IPhdProgramRepository
    {
        private readonly PhdSystemDbContext _context;

        public PhdProgramRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddPhdProgram(PhdProgram phdProgram)
        {
            var existingPhdProgram = await _context.PhdPrograms
                                                   .SingleOrDefaultAsync(pp => pp.Name.Equals(phdProgram.Name)
                                                                         && pp.ProfessionalFieldId.Equals(phdProgram.ProfessionalFieldId));

            if (existingPhdProgram != null)
            {
                throw new AlreadyExistsException(typeof(PhdProgram).Name, "name", existingPhdProgram.Name);
            }

            _context.Add(phdProgram);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePhdProgram(int phdProgramId)
        {
            var phdProgram = await _context.PhdPrograms.SingleOrDefaultAsync(p => p.Id.Equals(phdProgramId));

            if (phdProgram == null)
            {
                throw new NotFoundException(typeof(PhdProgram).Name, phdProgramId);
            }

            _context.Remove(phdProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhdProgram>> GetPhdPrograms(int professionalField)
        {
            return await _context.PhdPrograms.Where(p => p.ProfessionalFieldId == professionalField).ToListAsync();
        }

        public async Task<IEnumerable<PhdProgram>> GetPhdPrograms()
        {
            return await (from pp in _context.PhdPrograms
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
        }
    }
}
