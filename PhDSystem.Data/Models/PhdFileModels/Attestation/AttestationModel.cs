using System.Collections.Generic;

namespace PhDSystem.Data.Models.PhdFileModels.Attestation
{
    public class AttestationModel
    {
        public string UniversityName { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
        public string DissertationTheme { get; set; }
        public StudentPhdFileModel Student { get; set; }
        public IList<ExamAttestationModel> Exams { get; set; } = new List<ExamAttestationModel>();
        public IList<TeacherPhdFileModel> Teachers { get; set; } = new List<TeacherPhdFileModel>();
    }
}
