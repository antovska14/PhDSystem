using PhDSystem.Api.Models.Students;
using PhDSystem.Api.Models.Teachers;

namespace PhDSystem.Api.Models.IndividualPlans.Request
{
    public class IndividualPlanRequestModel
    {
        public string Theme { get; set; }
        public Student Student { get; set; }
        public Teacher Supervisor { get; set; }
        public Teacher Dean { get; set; }
    }
}
