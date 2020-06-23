using PhDSystem.Data.Models.PhdFileModels.Annotation;
using System.Collections.Generic;

namespace PhDSystem.Data.Models.PhdFileModels.Annotation
{
    public class AnnotationModel
    {
        public string UniversityName { get; set; }

        public FacultyAnnotationModel Faculty { get; set; }

        public string DepartmentName { get; set; }

        public string DissertationTheme { get; set; }

        public StudentAnnotationModel Student { get; set; }

        public IList<TeacherAnnotationModel> Teachers { get; set; } = new List<TeacherAnnotationModel>();
    }
}
