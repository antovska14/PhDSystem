using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
            var studentFileRecord = new StudentFile() { StudentId = studentId, FileGroup = fileGroup, FileName = fileName };
            _context.StudentFiles.Add(studentFileRecord);
            await _context.SaveChangesAsync();
        }
    }
}
