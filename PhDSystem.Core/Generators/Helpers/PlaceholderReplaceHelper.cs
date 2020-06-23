using PhDSystem.Core.Constants;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
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
    }
}
