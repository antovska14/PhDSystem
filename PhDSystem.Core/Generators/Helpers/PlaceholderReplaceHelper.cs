using PhDSystem.Core.Constants;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
using PhDSystem.Data.Models.PhdFileModels.Attestation;
using PhDSystem.Data.Models.PhdFileModels.IndividualPlan;
using System.Collections.Generic;

namespace PhDSystem.Core.Generators.Helpers
{
    public static class PlaceholderReplaceHelper
    {
        public static IDictionary<string, string> GetAnnotationPlaceholderValueDictionary(AnnotationModel annotation)
        {
            var placeholderValueDictionary = new Dictionary<string, string>();

            placeholderValueDictionary.Add(TemplatePlaceholderConstants.University, annotation.UniversityName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Faculty, annotation.Faculty.Name.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Department, annotation.DepartmentName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.DissertationTheme, annotation.DissertationTheme ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentFirstName, annotation.Student.FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentMiddleName, annotation.Student.MiddleName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentLastName, annotation.Student.LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherTitle, annotation.Teachers[0].Title ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherDegree, annotation.Teachers[0].Degree ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherFirstName, annotation.Teachers[0].FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherLastName, annotation.Teachers[0].LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.DeanFullName, annotation.Faculty.DeanFullName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachers, string.Empty);

            return placeholderValueDictionary;
        }

        public static IDictionary<string, string> GetAttestationPlaceholderValueDictionary(AttestationModel attestation)
        {
            var placeholderValueDictionary = new Dictionary<string, string>();

            placeholderValueDictionary.Add(TemplatePlaceholderConstants.University, attestation.UniversityName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Faculty, attestation.FacultyName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Department, attestation.DepartmentName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.FormOfEducation, attestation.Student.FormOfEducation ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.DissertationTheme, attestation.DissertationTheme ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentFirstName, attestation.Student.FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentMiddleName, attestation.Student.MiddleName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentLastName, attestation.Student.LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StartDate, attestation.Student.StartDate.Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.EndDate, attestation.Student.EndDate.Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherTitle, attestation.Teachers[0].Title ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherDegree, attestation.Teachers[0].Degree ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherFirstName, attestation.Teachers[0].FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherLastName, attestation.Teachers[0].LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.ExamName, attestation.Exams[0].Name ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.ExamDate, attestation.Exams[0].Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.GradeType, attestation.Exams[0].GradeType ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Grade, attestation.Exams[0].Grade.ToString("#.#") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachers, string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiExams, string.Empty);

            return placeholderValueDictionary;
        }

        public static IDictionary<string, string> GetIndividualPlanPlaceholderValueDictionary(IndividualPlanModel attestation)
        {
            var placeholderValueDictionary = new Dictionary<string, string>();

            placeholderValueDictionary.Add(TemplatePlaceholderConstants.University, attestation.UniversityName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Faculty, attestation.FacultyName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Department, attestation.DepartmentName.ToUpperInvariant() ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.FormOfEducation, attestation.Student.FormOfEducation ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.DissertationTheme, attestation.DissertationTheme ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SpecialtyName, attestation.SpecialtyName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.FacultyCouncilChosenDate, attestation.FacultyCouncilChosenDate.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentFirstName, attestation.Student.FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentMiddleName, attestation.Student.MiddleName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StudentLastName, attestation.Student.LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.StartDate, attestation.Student.StartDate.Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.EndDate, attestation.Student.EndDate.Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherTitle, attestation.Teachers[0].Title ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherDegree, attestation.Teachers[0].Degree ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherFirstName, attestation.Teachers[0].FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.TeacherLastName, attestation.Teachers[0].LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.HeadOfUnitFullName, string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersSignature, string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersBracesValue, string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersValue, string.Empty);
            placeholderValueDictionary.Add("()", string.Empty);

            for(int i = 0; i < attestation.Teachers.Count; i++)
            {
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersSignatureIndex.Replace("index", i.ToString()), "Научен ръководител: ……….……….……….");
                var teacherString = ($"{attestation.Teachers[i].Title} {attestation.Teachers[i].Degree} {attestation.Teachers[i].FirstName} {attestation.Teachers[i].LastName}").Trim();
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersBracesValueIndex.Replace("index", i.ToString()), $"({teacherString})");
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersValueIndex.Replace("index", i.ToString()), $"{teacherString}");
            }

            return placeholderValueDictionary;
        }
    }
}
