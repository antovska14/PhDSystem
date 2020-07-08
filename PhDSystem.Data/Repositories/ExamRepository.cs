using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Exceptions;
using PhDSystem.Data.Models.Exams;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly PhdSystemDbContext _context;

        public ExamRepository(PhdSystemDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int examId)
        {
            var exam = await _context.Exams.SingleOrDefaultAsync(e => e.Id.Equals(examId));

            if(exam == null)
            {
                throw new NotFoundException(typeof(Exam).Name, examId);
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExamDetails>> GetExams(int studentId)
        {
            return await _context.Exams.Where(e => e.StudentId == studentId).Select(x => new ExamDetails
            {
                Id = x.Id,
                StudentId = x.StudentId,
                Year = x.Year,
                Name = x.Name,
                Date = x.Date,
                Grade = x.Grade
            }).ToListAsync();
        }
    }
}
