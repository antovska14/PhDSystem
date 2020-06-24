using NetModular.DocX.Core;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Generators.Helpers;
using PhDSystem.Core.Generators.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Data.Models.PhdFileModels.IndividualPlan;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhDSystem.Core.Generators
{
    public class IndividualPlanGenerator : IPhdFileGenerator
    {
        private readonly FileModel _template;
        private readonly IndividualPlanModel _data;

        public IndividualPlanGenerator(FileModel template, IndividualPlanModel data)
        {
            _template = template;
            _data = data;
        }

        public FileModel GenerateFile()
        {
            var placeholderValueDictionary = PlaceholderReplaceHelper.GetIndividualPlanPlaceholderValueDictionary(_data);
            var templateFileStream = _template.FileContent;
            var placeholderRegex = new Regex("<\\w+>");

            var teacherStrings = new List<string>(); 
            foreach(var teacher in _data.Teachers)
            {
                teacherStrings.Add($"{teacher.Title} {teacher.Degree} {teacher.FirstName} {teacher.LastName}".Trim());
            }

            using (var document = DocX.Load(templateFileStream))
            {
                var maxTeacherIndex = _data.Teachers.Count;
                foreach (var paragraph in document.Paragraphs)
                {
                    var matchCollection = placeholderRegex.Matches(paragraph.Text);
                    var matches = matchCollection.Cast<Match>().Select(m => m.Value).ToList();
                    var areTeachersInit = false;
                    List<Paragraph> teacherSig = new List<Paragraph>();
                    List<Paragraph> teacherVal = new List<Paragraph>();

                    if (matches.Contains(TemplatePlaceholderConstants.MultiTeachersSignature) && !areTeachersInit)
                    {
                        for (int i = 0; i < _data.Teachers.Count; i++)
                        {
                            teacherSig.Add(paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersSignatureIndex.Replace("index", i.ToString())]).Bold());
                            paragraph.AppendLine();
                        }
                    }
                    else if (matches.Contains(TemplatePlaceholderConstants.MultiTeachersBracesValue) && !areTeachersInit)
                    {
                        for (int i = 0; i < _data.Teachers.Count; i++)
                        {
                            teacherVal.Add(paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersBracesValueIndex.Replace("index", i.ToString())]));
                            paragraph.AppendLine();
                        }
                        for (int i = 0; i < _data.Teachers.Count; i++)
                        {

                        }

                        areTeachersInit = true;
                    }
                    else if (matches.Contains(TemplatePlaceholderConstants.MultiTeachersValue))
                    {
                        for (int i = 0; i < _data.Teachers.Count; i++)
                        {
                            teacherVal.Add(paragraph.AppendLine(placeholderValueDictionary[TemplatePlaceholderConstants.MultiTeachersValueIndex.Replace("index", i.ToString())]));
                            paragraph.AppendLine();
                        }
                    }
                }

                foreach (var paragraph in document.Paragraphs)
                {
                    var matchCollection = placeholderRegex.Matches(paragraph.Text);
                    var matches = matchCollection.Cast<Match>().Select(m => m.Value).ToList();

                    foreach (var match in matches)
                    {
                        paragraph.ReplaceText(match, placeholderValueDictionary[match]);
                        paragraph.ReplaceText("()", string.Empty);
                    }
                }

                var memoryStream = new MemoryStream();
                document.SaveAs(memoryStream);

                return new FileModel
                {
                    FileName = FileConstants.IndividualPlanWordFileName,
                    FileContent = memoryStream,
                    ContentType = FileConstants.WordFileContentType
                };
            }
        }
    }
}
