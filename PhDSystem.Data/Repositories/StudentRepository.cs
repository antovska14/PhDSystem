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

        public async Task<Student> GetStudent(int studentId)
        {
            return await _context.Students.Where(s => s.Id == studentId).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetSupervisorStudents(int supervisorId)
        {
            throw new NotImplementedException();
        }

        public async Task AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public Task UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}