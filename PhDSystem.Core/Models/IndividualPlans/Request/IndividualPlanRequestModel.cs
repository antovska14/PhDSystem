using PhDSystem.Data.POCOs;

namespace PhDSystem.Core.Models.IndividualPlans.Request
{
    public class IndividualPlanRequestModel
    {
        public string Theme { get; set; }
        public Student Student { get; set; }
        public Teacher Supervisor { get; set; }
        public Teacher Dean { get; set; }
    }
}
