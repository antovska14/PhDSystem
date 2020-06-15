using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PhdSystemContext _context;

        public StudentRepository(PhdSystemContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == studentId);
            student.IsDeleted = true;

            var user = await (from s in _context.Students
                              join u in _context.Users on s.UserId equals u.Id
                              where s.Id == studentId
                              select u).SingleOrDefaultAsync();

            user.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetStudentAsync(int studentId)
        {
            var student = await _context.Students.Where(s => s.Id == studentId).SingleOrDefaultAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsBySupervisorAsync(int supervisorId)
        {
            return await (from s in _context.Students
                          join st in _context.StudentTeachers on s.Id equals st.StudentId
                          join t in _context.Teachers on st.TeacherId equals t.Id
                          where t.Id == supervisorId
                          select s).ToListAsync();
        }

        public async Task UpdateStudentAsync(int studentId, Student student)
        {
            var studentToUpdate = _context.Students.SingleOrDefault(s => s.Id == student.Id);
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.MiddleName = student.MiddleName;
            studentToUpdate.LastName = student.LastName;
            await _context.SaveChangesAsync();
        }
    }
}