using PhDSystem.Core.Constants;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
using PhDSystem.Data.Models.PhdFileModels.Attestation;
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
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorTitle, annotation.Teachers[0].Title ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorDegree, annotation.Teachers[0].Degree ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorFirstName, annotation.Teachers[0].FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorLastName, annotation.Teachers[0].LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.DeanFullName, annotation.Faculty.DeanFullName ?? string.Empty);
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
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorTitle, attestation.Teachers[0].Title ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorDegree, attestation.Teachers[0].Degree ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorFirstName, attestation.Teachers[0].FirstName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.SupervisorLastName, attestation.Teachers[0].LastName ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.ExamName, attestation.Exams[0].Name ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.ExamDate, attestation.Exams[0].Date.ToString("dd/MM/yyyy") ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.GradeType, attestation.Exams[0].GradeType ?? string.Empty);
            placeholderValueDictionary.Add(TemplatePlaceholderConstants.Grade, attestation.Exams[0].Grade.ToString("#.#") ?? string.Empty);
            return placeholderValueDictionary;
        }
    }
}
