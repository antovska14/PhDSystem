using PhDSystem.Core.Constants;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Generators;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Core.Services
{
    public class PhdFileService : IPhdFileService
    {
        private readonly IPhdFileDataRepository _phdFileDataRepository;
        private readonly IFileManager _fileManager;

        public PhdFileService(IPhdFileDataRepository phdFileDataRepository, IFileManager fileManager)
        {
            _phdFileDataRepository = phdFileDataRepository;
            _fileManager = fileManager;
        }

        public async Task<FileModel> ExportStudentFile(PhdFileType documentType, int studentId, int year = 0)
        {
            AttestationGenerator generator = null;

            if (documentType == PhdFileType.IndividualPlan)
            {
                //var data = await _phdFileDataRepository.GetIndividualPlanData(studentId);
                //generator = new IndividualPlanGenerator(data);
            }
            else if (documentType == PhdFileType.Annotation)
            {
                var template = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.AnnotationWordFileName);
                var data = await _phdFileDataRepository.GetAnnotationData(studentId);
                //generator = new AnnotationGenerator(template, data);
            }
            else if (documentType == PhdFileType.Attestation)
            {
                var template = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.AttestationWordFileName);
                var data = await _phdFileDataRepository.GetAttestationData(studentId, year);
                generator = new AttestationGenerator(template, data);
            }

            if (generator == null)
            {
                throw new ArgumentNullException();
            }

            return generator.GenerateFile();
        }


        //private async Task<FileModel> GetIndividualPlan(int studentId)
        //{
        //    var students = await _studentData.GetStudentsAsync();

        //    var request = new IndividualPlanRequestModel
        //    {
        //        Student = new Student
        //        {
        //            FirstName = "StudentFirstName",
        //            MiddleName = null,
        //            LastName = "StudentLastName"
        //        },
        //        Supervisor = new Teacher
        //        {
        //            FirstName = "SupervisorFisrtName",
        //            MiddleName = null,
        //            LastName = "SupervisorLastName"
        //        },
        //        Dean = new Teacher
        //        {
        //            FirstName = "DeanFisrtName",
        //            MiddleName = null,
        //            LastName = "DeanLastName"
        //        },
        //        Theme = "Theme"
        //    };

        //    var individualPlanKeywords = GetIndividualPlanKeywords(request);
        //    var templateFile = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.IndividualPlanTemplate);
        //    var templateFileStream = templateFile.FileContent;


        //    string resultFileName = "IndividualPlan.docx";
        //    string resultFilePath = Path.Combine(Environment.CurrentDirectory, "Files", FileConstants.UserFilesFolder, studentId.ToString(), resultFileName);

        //    using (var document = DocX.Load(templateFileStream))
        //    {
        //        for (int i = 0; i < document.Paragraphs.Count; i++)
        //        {
        //            Paragraph templateParagraph = document.Paragraphs[i];
        //            var keywordsRegex = new Regex("<\\w+>");
        //            MatchCollection matchCollection = keywordsRegex.Matches(templateParagraph.Text);
        //            string[] matches = matchCollection.Cast<Match>().Select(x => x.Value).ToArray();
        //            foreach (var match in matches)
        //            {
        //                templateParagraph.ReplaceText(match, individualPlanKeywords[match]);
        //            }
        //        }

        //        var memoryStream = new MemoryStream();
        //        document.SaveAs(memoryStream);

        //        var fileModel = new FileModel
        //        {
        //            FileContent = memoryStream,
        //            FileName = resultFileName,
        //            ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document; charset=UTF-8"
        //        };

        //        return fileModel;
        //    }
        //}

        //private IDictionary<string, string> GetIndividualPlanKeywords(IndividualPlanRequestModel data)
        //{
        //    IDictionary<string, string> keywords = new Dictionary<string, string>();

        //    keywords.Add("<theme>", data.Theme ?? "");
        //    keywords.Add("<firstName>", data.Student.FirstName ?? "");
        //    keywords.Add("<middleName>", data.Student.MiddleName ?? "");
        //    keywords.Add("<lastName>", data.Student.LastName ?? "");
        //    keywords.Add("<title>", "");
        //    keywords.Add("<supervisorFullName>", "");
        //    keywords.Add("<supervisorTitle>", "");
        //    keywords.Add("<supervisorDegree>", "");
        //    keywords.Add("<deanFullName>", "");
        //    keywords.Add("<deanTitle>", "");
        //    keywords.Add("<faculty>", "");
        //    keywords.Add("<department>", "");
        //    keywords.Add("<specialty>", "");
        //    keywords.Add("<>", "");
        //    keywords.Add("<date>", "");
        //    keywords.Add("<dissertationDescription>", "");
        //    keywords.Add("<formOfEducation>", "");
        //    keywords.Add("<headOfUnitTitle>", "");
        //    keywords.Add("<headOfUnitFullName>", "");

        //    keywords.Add("<degree>", "");
        //    keywords.Add("<schoolYear>", "");
        //    keywords.Add("<startDate>", "");
        //    keywords.Add("<endDate>", "");
        //    keywords.Add("<fullName>", "");

        //    return keywords;
        //}
        //}
    }
}
