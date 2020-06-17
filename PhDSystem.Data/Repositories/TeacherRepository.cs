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

        public async Task<Teacher> GetTeacherAsync(int teacherId)
        {
            return await _context.Teachers.Where(t => t.Id == teacherId && t.IsDeleted == false).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _context.Teachers.Where(t => t.IsDeleted == false).ToListAsync();
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
