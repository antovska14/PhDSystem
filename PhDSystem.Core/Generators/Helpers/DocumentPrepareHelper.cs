using NetModular.DocX.Core;
using PhDSystem.Core.Constants;
using PhDSystem.Data.Models.PhdFileModels;
using PhDSystem.Data.Models.PhdFileModels.Attestation;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhDSystem.Core.Generators.Helpers
{
    public static class DocumentPrepareHelper
    {
        public static void PrepareTeachers(DocX document, IList<TeacherPhdFileModel> teachers, Regex placeholderRegex, IDictionary<string, string> placeholderValueDictionary)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                var matchCollection = placeholderRegex.Matches(paragraph.Text);
                var matches = matchCollection.Cast<Match>().Select(m => m.Value).ToList();

                if (matches.Contains(TemplatePlaceholderConstants.MultiTeachersSignatureValuePair))
                {
                    for (int i = 0; i < teachers.Count; i++)
                    {
                        paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersSignatureIndex.Replace("index", i.ToString())]).Bold();
                        paragraph.AppendLine();
                        paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersBracesValueIndex.Replace("index", i.ToString())]).Bold();
                        paragraph.AppendLine();
                        paragraph.AppendLine();
                    }
                }

                if (matches.Contains(TemplatePlaceholderConstants.MultiTeachersValue))
                {
                    for (int i = 0; i < teachers.Count; i++)
                    {
                        paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersValueIndex.Replace("index", i.ToString())]);
                        paragraph.AppendLine();
                    }
                }
            }
        }

        public static void PrepareExams(DocX document, IList<ExamAttestationModel> exams, Regex placeholderRegex, IDictionary<string, string> placeholderValueDictionary)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                var matchCollection = placeholderRegex.Matches(paragraph.Text);
                var matches = matchCollection.Cast<Match>().Select(m => m.Value).ToList();

                if (matches.Contains(TemplatePlaceholderConstants.MultiExamsValue))
                {
                    for (int i = 0; i < exams.Count; i++)
                    {
                        paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiExamsValueIndex.Replace("index", i.ToString())]);
                        paragraph.AppendLine();
                    }
                }
            }
        }
    }
}
