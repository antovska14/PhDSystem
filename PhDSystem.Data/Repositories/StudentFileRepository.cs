using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class StudentFileRepository : IStudentFileRepository
    {
        private readonly PhdSystemDbContext _context;

        public StudentFileRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task CreateStudentFileRecord(int studentId, string fileGroup, string fileName)
        {
            var studentFileRecord = new StudentFile { StudentId = studentId, FileGroup = fileGroup, FileName = fileName };

            _context.StudentFiles.Add(studentFileRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentFileRecord(int studentId, string fileGroup, string fileName)
        {
            var studentFileRecord = await _context.StudentFiles.Where(sf => sf.StudentId.Equals(studentId)
                                                                      && sf.FileGroup.Equals(fileGroup)
                                                                      && sf.FileName.Equals(fileName)).SingleOrDefaultAsync();

            if (studentFileRecord != null)
            {
                _context.StudentFiles.Remove(studentFileRecord);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StudentFileDetails> GetStudentFileNames(int studentId, string fileGroup)
        {
            var fileNames = await (from sf in _context.StudentFiles
                                   where sf.StudentId == studentId
                                   && sf.FileGroup.Equals(fileGroup)
                                   select sf.FileName).ToListAsync();

            return new StudentFileDetails
            {
                StudentId = studentId,
                FileGroup = fileGroup,
                FileNames = fileNames
            };
        }
    }
}
