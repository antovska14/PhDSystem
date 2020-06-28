using PhDSystem.Data.Entities;
using PhDSystem.Data.Models.Exams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IExamRepository
    {
        Task AddExam(Exam exam);

        Task DeleteExam(int examId);

        Task<IEnumerable<ExamsYearDetails>> GetExams(int studentId);
    }
}
