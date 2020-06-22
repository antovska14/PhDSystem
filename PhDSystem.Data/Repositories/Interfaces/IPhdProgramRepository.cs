using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IPhdProgramRepository
    {
        Task AddPhdProgram(PhdProgram phdProgram);

        Task DeletePhdProgram(int phdProgramId);

        Task GetPhdPrograms(int professionalField);
    }
}
