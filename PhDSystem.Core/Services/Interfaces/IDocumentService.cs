using PhDSystem.Core.Models;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<FileModel> GetIndividualPlan();
    }
}
