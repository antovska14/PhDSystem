using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IExamRepository
    {
        Task AddExam(Exam exam);

        Task DeleteExam(int examId);

        Task<Exam> GetExams(int studentId);
    }
}
