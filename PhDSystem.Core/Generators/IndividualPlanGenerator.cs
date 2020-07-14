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
            Stream templateFileStream = _template.FileContent;

            IDictionary<string, string> placeholderValueDictionary = PlaceholderReplaceHelper.GetIndividualPlanPlaceholderValueDictionary(_data);
            Regex placeholderRegex = new Regex("<\\w+>");

            using (var document = DocX.Load(templateFileStream))
            {
                DocumentPrepareHelper.PrepareTeachers(document, _data.Teachers, placeholderRegex, placeholderValueDictionary);

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
