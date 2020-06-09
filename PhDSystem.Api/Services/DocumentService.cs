using NPOI.XWPF.UserModel;
using PhDSystem.Api.Adapters;
using PhDSystem.Api.Constants;
using PhDSystem.Api.Managers.Interfaces;
using PhDSystem.Api.Models;
using PhDSystem.Api.Models.IndividualPlans.Request;
using PhDSystem.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IFileManager _fileManager;

        public DocumentService(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public async Task<FileModel> GetIndividualPlan(IndividualPlanRequestModel request)
        {
            var individualPlanKeywords = GetIndividualPlanKeywords(request);
            var templateFile = await _fileManager.GetFileAsync(FileConstants.TemplatesFolder, string.Empty, FileConstants.IndividualPlanTemplate);
            var templateFileStream = templateFile.FileContent;

            using (templateFileStream)
            using (WordFileAdapter document = new WordFileAdapter(new XWPFDocument(templateFileStream)))
            {
                int paragraphsCount = document.GetParagraphs().Count;
                for (int i = 0; i < paragraphsCount; i++)
                {
                    XWPFParagraph templateParagraph = document.GetParagraph(i);
                    var keywordsRegex = new Regex("<\\w+>");
                    MatchCollection matchCollection = keywordsRegex.Matches(templateParagraph.Text);
                    string[] matches = matchCollection.Select(x => x.Value).ToArray();
                    foreach (var match in matches)
                    {
                        templateParagraph.ReplaceText(match, individualPlanKeywords[match]);
                    }

                    document.CreateParagraph();
                    document.SetParagraph(templateParagraph, i);
                }

                string resultFileName = "Individual_Plan.docx";
                string resultFilePath = Path.Combine(Environment.CurrentDirectory, "Files", FileConstants.UserFilesFolder, FileConstants.UserFolder, resultFileName);
                Stream resultFileStream = File.OpenWrite(resultFilePath);
                document.Write(resultFileStream);

                var fileModel = new FileModel
                {
                    FileContent = document.AsStream(),z
                    FileName = resultFileName,
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document; charset=UTF-8"

                };
                return fileModel;
            }
        }

        private IDictionary<string, string> GetIndividualPlanKeywords(IndividualPlanRequestModel data)
        {
            IDictionary<string, string> keywords = new Dictionary<string, string>();

            keywords.Add("<theme>", data.Theme ?? "");
            keywords.Add("<firstName>", data.Student.FirstName ?? "");
            keywords.Add("<middleName>", data.Student.MiddleName ?? "");
            keywords.Add("<lastName>", data.Student.LastName ?? "");
            keywords.Add("<title>", data.Student.Title ?? "");
            keywords.Add("<supervisorFullName>", data.Supervisor.FullName ?? "");
            keywords.Add("<supervisorTitle>", data.Supervisor.Title ?? "");
            keywords.Add("<deanFullName>", data.Dean.FullName ?? "");
            keywords.Add("<deanTitle>", data.Dean.Title ?? "");
            keywords.Add("<faculty>", "");
            keywords.Add("<department>", "");
            keywords.Add("<specialty>", "");
            keywords.Add("<>", "");
            keywords.Add("<date>", "");
            keywords.Add("<dissertationDescription>", "");
            keywords.Add("<formOfEducation>", "");
            keywords.Add("<headOfUnitTitle>", "");
            keywords.Add("<headOfUnitFullName>", "");

            keywords.Add("<degree>", "");
            keywords.Add("<schoolYear>", "");
            keywords.Add("<startDate>", "");
            keywords.Add("<endDate>", "");
            keywords.Add("<fullName>", "");

            return keywords;
        }
    }
}
