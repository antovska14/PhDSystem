using PhDSystem.Api.Models;
using PhDSystem.Api.Models.IndividualPlans.Request;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services.Interfaces
{
    public interface IDocumentService
    {
        Task<FileModel> GetIndividualPlan();
    }
}
