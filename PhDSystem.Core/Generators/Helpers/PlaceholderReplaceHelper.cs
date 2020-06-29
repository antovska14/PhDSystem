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
            var placeholderValueDictionary = new Dictionary<string, string>
            {
                { TemplatePlaceholderConstants.University, annotation.UniversityName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Faculty, annotation.Faculty.Name.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Department, annotation.DepartmentName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.DissertationTheme, annotation.DissertationTheme ?? string.Empty },
                { TemplatePlaceholderConstants.StudentFirstName, annotation.Student.FirstName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentMiddleName, annotation.Student.MiddleName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentLastName, annotation.Student.LastName ?? string.Empty },
                { TemplatePlaceholderConstants.TeacherTitle, annotation.Teachers[0].Title ?? string.Empty },
                { TemplatePlaceholderConstants.TeacherDegree, annotation.Teachers[0].Degree ?? string.Empty },
                { TemplatePlaceholderConstants.TeacherFirstName, annotation.Teachers[0].FirstName ?? string.Empty },
                { TemplatePlaceholderConstants.TeacherLastName, annotation.Teachers[0].LastName ?? string.Empty },
                { TemplatePlaceholderConstants.DeanFullName, annotation.Faculty.DeanFullName ?? string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersSignature, string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersBracesValue, string.Empty },
                { "()", string.Empty }
            };

            for (int i = 0; i < annotation.Teachers.Count; i++)
            {
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersSignatureIndex.Replace("index", i.ToString()), "Научен ръководител: ……….……….……….");
                var teacherString = ($"{annotation.Teachers[i].Title} {annotation.Teachers[i].Degree} {annotation.Teachers[i].FirstName} {annotation.Teachers[i].LastName}").Trim();
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersBracesValueIndex.Replace("index", i.ToString()), $"({teacherString})");
            }

            return placeholderValueDictionary;
        }

        public static IDictionary<string, string> GetAttestationPlaceholderValueDictionary(AttestationModel attestation)
        {
            var placeholderValueDictionary = new Dictionary<string, string>
            {
                { TemplatePlaceholderConstants.University, attestation.UniversityName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Faculty, attestation.FacultyName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Department, attestation.DepartmentName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.FormOfEducation, attestation.Student.FormOfEducation ?? string.Empty },
                { TemplatePlaceholderConstants.DissertationTheme, attestation.DissertationTheme ?? string.Empty },
                { TemplatePlaceholderConstants.StudentFirstName, attestation.Student.FirstName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentMiddleName, attestation.Student.MiddleName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentLastName, attestation.Student.LastName ?? string.Empty },
                { TemplatePlaceholderConstants.StartDate, attestation.Student.StartDate.Date.ToString("dd.MM.yyyy") ?? string.Empty },
                { TemplatePlaceholderConstants.EndDate, attestation.Student.EndDate.Date.ToString("dd.MM.yyyy") ?? string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersValue, string.Empty },
                { TemplatePlaceholderConstants.MultiExamsValue, string.Empty }
            };

            for (int i = 0; i < attestation.Exams.Count; i++)
            {
                var examString = ($"По {attestation.Exams[i].Name} срок на явяване {attestation.Exams[i].Date:dd.MM.yyyy} с  {attestation.Exams[i].GradeType} оценка ({attestation.Exams[i].Grade:#.#}).").Trim();
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiExamsValueIndex.Replace("index", i.ToString()), $"({examString})");
            }

            for (int i = 0; i < attestation.Teachers.Count; i++)
            {
                var teacherString = ($"{attestation.Teachers[i].Title} {attestation.Teachers[i].Degree} {attestation.Teachers[i].FirstName} {attestation.Teachers[i].LastName}").Trim();
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersValueIndex.Replace("index", i.ToString()), $"{teacherString}");
            }

            return placeholderValueDictionary;
        }

        public static IDictionary<string, string> GetIndividualPlanPlaceholderValueDictionary(IndividualPlanModel individualPlan)
        {
            var placeholderValueDictionary = new Dictionary<string, string>
            {
                { TemplatePlaceholderConstants.University, individualPlan.UniversityName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Faculty, individualPlan.FacultyName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.Department, individualPlan.DepartmentName.ToUpperInvariant() ?? string.Empty },
                { TemplatePlaceholderConstants.FormOfEducation, individualPlan.Student.FormOfEducation ?? string.Empty },
                { TemplatePlaceholderConstants.DissertationTheme, individualPlan.DissertationTheme ?? string.Empty },
                { TemplatePlaceholderConstants.SpecialtyName, individualPlan.SpecialtyName ?? string.Empty },
                { TemplatePlaceholderConstants.FacultyCouncilChosenDate, individualPlan.FacultyCouncilChosenDate.ToString("dd/MM/yyyy") ?? string.Empty },
                { TemplatePlaceholderConstants.StudentFirstName, individualPlan.Student.FirstName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentMiddleName, individualPlan.Student.MiddleName ?? string.Empty },
                { TemplatePlaceholderConstants.StudentLastName, individualPlan.Student.LastName ?? string.Empty },
                { TemplatePlaceholderConstants.StartDate, individualPlan.Student.StartDate.Date.ToString("dd.MM.yyyy") ?? string.Empty },
                { TemplatePlaceholderConstants.EndDate, individualPlan.Student.EndDate.Date.ToString("dd.MM.yyyy") ?? string.Empty },
                { TemplatePlaceholderConstants.HeadOfUnitFullName, string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersSignature, string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersBracesValue, string.Empty },
                { TemplatePlaceholderConstants.MultiTeachersValue, string.Empty },
                { "()", string.Empty }
            };

            for (int i = 0; i < individualPlan.Teachers.Count; i++)
            {
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersSignatureIndex.Replace("index", i.ToString()), "Научен ръководител: ……….……….……….");
                var teacherString = ($"{individualPlan.Teachers[i].Title} {individualPlan.Teachers[i].Degree} {individualPlan.Teachers[i].FirstName} {individualPlan.Teachers[i].LastName}").Trim();
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersBracesValueIndex.Replace("index", i.ToString()), $"({teacherString})");
                placeholderValueDictionary.Add(TemplatePlaceholderConstants.MultiTeachersValueIndex.Replace("index", i.ToString()), $"{teacherString}");
            }

            return placeholderValueDictionary;
        }
    }
}
