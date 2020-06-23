using PhDSystem.Data.Models.PhdFileModels.Attestation;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
using PhDSystem.Data.Models.PhdFileModels.IndividualPlan;
using System.Threading.Tasks;

namespace PhDSystem.Data.Repositories.Interfaces
{
    public interface IPhdFileDataRepository
    {
        Task<AnnotationModel> GetAnnotationData(int studentId);

        Task<IndividualPlanModel> GetIndividualPlanData(int studentId);

        Task<AttestationModel> GetAttestationData(int studentId, int year);
    }
}
