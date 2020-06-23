using System;
using System.Collections.Generic;

namespace PhDSystem.Data.Models.PhdFileModels.IndividualPlan
{
    public class IndividualPlanModel
    {
        public string UniversityName { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string DissertationTheme { get; set; }
        public string SpecialtyName { get; set; }
        public DateTime FacultyCouncilChosenDate { get; set; }
        public StudentPhdFileModel Student { get; set; }
        public IList<TeacherPhdFileModel> Teachers { get; set; } = new List<TeacherPhdFileModel>();

    }
}
