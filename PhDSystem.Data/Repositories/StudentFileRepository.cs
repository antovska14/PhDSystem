using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class StudentFileRepository : IStudentFileRepository
    {
        private readonly PhdSystemDbContext _context;

        public StudentFileRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateStudentFileRecord(int studentId, string fileGroup, string fileName)
        {
            var studentFileRecord = new StudentFile
            {
                StudentId = studentId,
                FileGroup = fileGroup,
                FileName = fileName
            };

            _context.StudentFiles.Add(studentFileRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentFileRecord(int studentId, string fileGroup, string fileName)
        {
            var studentFileRecord = await SearchFile(studentId, fileGroup, fileName);

            if (studentFileRecord != null)
            {
                _context.StudentFiles.Remove(studentFileRecord);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> FileExists(int studentId, string fileGroup, string fileName)
        {
            var existingFile = await SearchFile(studentId, fileGroup, fileName);
            if(existingFile != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<StudentFileGroupDetails>> GetStudentFileDetailsList(int studentId)
        {
            var fileGroupFilesDictionary = new Dictionary<string, IList<string>>();

            var studentFiles = await _context.StudentFiles.Where(sf => sf.StudentId == studentId).ToListAsync();

            foreach (var studentFile in studentFiles)
            {
                if (fileGroupFilesDictionary.TryGetValue(studentFile.FileGroup, out var fileNames))
                {
                    fileNames.Add(studentFile.FileName);
                }
                else
                {
                    fileGroupFilesDictionary.Add(studentFile.FileGroup, new List<string> { studentFile.FileName });
                }
            }

            var studentFileDetailsList = new List<StudentFileGroupDetails>();

            foreach (var keyValuePair in fileGroupFilesDictionary)
            {
                studentFileDetailsList.Add(new StudentFileGroupDetails
                {
                    StudentId = studentId,
                    FileGroup = keyValuePair.Key,
                    FileNames = keyValuePair.Value
                });
            }

            return studentFileDetailsList;
        }

        private async Task<StudentFile> SearchFile(int studentId, string fileGroup, string fileName)
        {
            return await _context.StudentFiles.SingleOrDefaultAsync(sf => sf.StudentId == studentId
                                                                    && sf.FileGroup.Equals(fileGroup)
                                                                    && sf.FileName.Equals(fileName));
        }
    }
}
