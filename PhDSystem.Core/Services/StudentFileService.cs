using Microsoft.AspNetCore.Http;
using NetModular.DocX.Core;
using PhDSystem.Core.Constants;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Managers.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Models.IndividualPlans.Request;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhDSystem.Api.Services
{
    public class StudentFileService : IStudentFileService
    {
        private readonly IFileManager _fileManager;
        private readonly IStudentRepository _studentData;
        private readonly IStudentFileRepository _studentFileRepository;

        public StudentFileService(IFileManager fileManager, IStudentRepository studentData, IStudentFileRepository studentFileRepository)
        {
            _fileManager = fileManager;
            _studentData = studentData;
            _studentFileRepository = studentFileRepository;
        }

        public async Task DeleteStudentFile(string fileName, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);

            _fileManager.DeleteFile(new string[] { FileConstants.UserFilesFolder, fileGroup }, fileName);

            await _studentFileRepository.DeleteStudentFileRecord(studentId, fileGroup, fileName);
        }

        public async Task<FileModel> ExportStudentFile(StudentFileType documentType, int studentId, int year)
        {
            FileModel fileResult = null;

            if(documentType == StudentFileType.IndividualPlan)
            {
                fileResult = await GetIndividualPlan(studentId);
            }

            return fileResult;
        }

        public async Task UploadStudentFile(IFormFile file, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);

            await _fileManager.StoreFileAsync(new string[] { FileConstants.UserFilesFolder, fileGroup }, file);

            await _studentFileRepository.CreateStudentFileRecord(studentId, fileGroup, file.FileName);
        }

        public async Task<FileModel> DownloadStudentFile(string fileName, int studentId, int year)
        {
            string fileGroup = GetFileGroup(year);

            var resultFile = await _fileManager.GetFileAsync(new string[] { FileConstants.UserFilesFolder, fileGroup }, fileName);

            return resultFile;
        }

        private string GetFileGroup(int year)
        {
            return year == 0 ? year.ToString() : FileConstants.GeneralFolder;
        }

        private async Task<FileModel> GetIndividualPlan(int studentId)
        {
            var students = await _studentData.GetStudentsAsync();

            var request = new IndividualPlanRequestModel
            {
                Student = new Student
                {
                    FirstName = "StudentFirstName",
                    MiddleName = null,
                    LastName = "StudentLastName"
                },
                Supervisor = new Teacher
                {
                    FirstName = "SupervisorFisrtName",
                    MiddleName = null,
                    LastName = "SupervisorLastName"
                },
                Dean = new Teacher
                {
                    FirstName = "DeanFisrtName",
                    MiddleName = null,
                    LastName = "DeanLastName"
                },
                Theme = "Theme"
            };

            var individualPlanKeywords = GetIndividualPlanKeywords(request);
            var templateFile = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.IndividualPlanTemplate);
            var templateFileStream = templateFile.FileContent;


            string resultFileName = "IndividualPlan.docx";
            string resultFilePath = Path.Combine(Environment.CurrentDirectory, "Files", FileConstants.UserFilesFolder, studentId.ToString(), resultFileName);

            using (var document = DocX.Load(templateFileStream))
            {
                for (int i = 0; i < document.Paragraphs.Count; i++)
                {
                    Paragraph templateParagraph = document.Paragraphs[i];
                    var keywordsRegex = new Regex("<\\w+>");
                    MatchCollection matchCollection = keywordsRegex.Matches(templateParagraph.Text);
                    string[] matches = matchCollection.Cast<Match>().Select(x => x.Value).ToArray();
                    foreach (var match in matches)
                    {
                        templateParagraph.ReplaceText(match, individualPlanKeywords[match]);
                    }
                }

                var memoryStream = new MemoryStream();
                document.SaveAs(memoryStream);

                var fileModel = new FileModel
                {
                    FileContent = memoryStream,
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
            keywords.Add("<title>", "");
            keywords.Add("<supervisorFullName>", "");
            keywords.Add("<supervisorTitle>", "");
            keywords.Add("<supervisorDegree>", "");
            keywords.Add("<deanFullName>", "");
            keywords.Add("<deanTitle>", "");
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
