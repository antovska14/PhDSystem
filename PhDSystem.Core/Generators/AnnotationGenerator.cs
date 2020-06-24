using NetModular.DocX.Core;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Generators.Helpers;
using PhDSystem.Core.Generators.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Data.Models.PhdFileModels.Annotation;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace PhDSystem.Core.Generators
{
    public class AnnotationGenerator : IPhdFileGenerator
    {
        private FileModel _template;
        private AnnotationModel _data;

        public AnnotationGenerator(FileModel template, AnnotationModel data)
        {
            _template = template;
            _data = data;
        }

        public FileModel GenerateFile()
        {
            var placeholderValueDictionary = PlaceholderReplaceHelper.GetAnnotationPlaceholderValueDictionary(_data);
            var templateFileStream = _template.FileContent;
            var placeholderRegex = new Regex("<\\w+>");

            using(var document = DocX.Load(templateFileStream))
            {
                foreach(var paragraph in document.Paragraphs)
                {
                    var matchCollection = placeholderRegex.Matches(paragraph.Text);
                    var matches = matchCollection.Cast<Match>().Select(m => m.Value).ToList();
                    foreach(var match in matches)
                    {
                        paragraph.ReplaceText(match, placeholderValueDictionary[match]);
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
