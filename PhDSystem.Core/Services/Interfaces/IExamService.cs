using PhDSystem.Data.Models.Exams;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IExamService
    {
        Task<IEnumerable<ExamsYearDetails>> GetExams(int studentId);
    }
}
