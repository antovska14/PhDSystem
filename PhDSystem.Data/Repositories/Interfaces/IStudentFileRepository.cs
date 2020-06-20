using PhDSystem.Data.Models;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IStudentFileRepository
    {
        Task CreateStudentFileRecord(int studentId, string fileGroup, string fileName);

        Task DeleteStudentFileRecord(int studentId, string fileGroup, string fileName);

        Task<StudentFileDetails> GetStudentFileNames(int studentId, string fileGroup);
    }
}
