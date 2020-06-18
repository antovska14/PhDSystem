using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly PhdSystemDbContext _context;

        public TeacherRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task CreateTeacherAsync(TeacherDetails teacherDetails)
        {
            var teacher = new Teacher()
            {
                FirstName = teacherDetails.FirstName,
                MiddleName = teacherDetails.MiddleName,
                LastName = teacherDetails.LastName,
                UserId = teacherDetails.UserId
            };

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int teacherId)
        {
            var teacherToDelete = await _context.Teachers.Where(t => t.Id == teacherId).SingleOrDefaultAsync();
            teacherToDelete.IsDeleted = true;

            var user = await (from s in _context.Teachers
                              join u in _context.Users on s.UserId equals u.Id
                              where s.Id == teacherId
                              select u).SingleOrDefaultAsync();

            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<TeacherDetails> GetTeacherAsync(int teacherId)
        {
            var teacher = await (from t in _context.Teachers
                                  where t.Id == teacherId && t.IsDeleted == false
                                  select new TeacherDetails()
                                  {
                                      Id = t.Id,
                                      FirstName = t.FirstName,
                                      MiddleName = t.MiddleName,
                                      LastName = t.LastName,
                                  }).SingleOrDefaultAsync();

            return teacher;
        }

        public async Task<IEnumerable<TeacherDetails>> GetTeachersAsync()
        {
            var teachers = await (from t in _context.Teachers
                                  join u in _context.Users on t.UserId equals u.Id
                                  where t.IsDeleted == false
                                  select new TeacherDetails()
                                  {
                                      Id = t.Id,
                                      UserId = u.Id,
                                      FirstName = t.FirstName,
                                      MiddleName = t.MiddleName,
                                      LastName = t.LastName,
                                      Email = u.Email
                                  }).ToListAsync();

            return teachers;
        }

        public async Task UpdateTeacherAsync(int teacherId, TeacherDetails teacherDetails)
        {
            var existingTeacher = await _context.Teachers.Where(t => t.Id == teacherId).SingleOrDefaultAsync();
            existingTeacher.FirstName = teacherDetails.FirstName;
            existingTeacher.MiddleName = teacherDetails.MiddleName;
            existingTeacher.LastName = teacherDetails.LastName;
            await _context.SaveChangesAsync();
        }
    }
}
