using System.Collections.Generic;

namespace PhDSystem.Data.Models.PhdFileModels.Annotation
{
    public class AnnotationModel
    {
        public string UniversityName { get; set; }

        public FacultyAnnotationModel Faculty { get; set; }

        public string DepartmentName { get; set; }

        public string DissertationTheme { get; set; }

        public StudentPhdFileModel Student { get; set; }

        public IList<TeacherPhdFileModel> Teachers { get; set; } = new List<TeacherPhdFileModel>();
    }
}
