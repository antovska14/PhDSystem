using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly PhdSystemDbContext _context;

        public ExamRepository(PhdSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExam(int examId)
        {
            var exam = await _context.Exams.Where(e => e.Id.Equals(examId)).SingleOrDefaultAsync();
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public Task<Exam> GetExams(int studentId)
        {
            //TODO [DA]: Implement this following the logic from StudentFileRepository
            throw new System.NotImplementedException();
        }
    }
}
