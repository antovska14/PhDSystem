using NPOI.XWPF.UserModel;
using PhDSystem.Api.Constants;
using PhDSystem.Api.Managers.Interfaces;
using System;
using System.IO;

namespace PhDSystem.Api.Managers
{
    public class FileManager : IFileManager
    {
        public Stream GetIndividualPlan()
        {
            var templateFilePath = Path.Combine(FileConstants.TemplateFilesDirectory, FileConstants.IndividualPlanTemplate);
            var templateFileStream = File.OpenRead(templateFilePath);

            var uniqueIdentifier = new Guid();
            var resultFilePath = Path.Combine(FileConstants.IndividualPlansResultDirectory, $"{uniqueIdentifier}_Individual_Plan.docx");
            var resultFileStream = File.OpenWrite(resultFilePath);
            PrepareFile(templateFileStream, resultFileStream);
            return resultFileStream;
        }

        private void PrepareFile(Stream inputFile, Stream outputFile)
        {
            XWPFDocument doc = new XWPFDocument(inputFile);
            XWPFDocument resultDoc = new XWPFDocument();
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                var paragraph = doc.Paragraphs[i];
                if (doc.Paragraphs[i].Text.Contains("<theme>"))
                {
                    paragraph.ReplaceText("<theme>", "NEW VALUE");
                }

                resultDoc.CreateParagraph();
                resultDoc.SetParagraph(paragraph, i);
            }

            resultDoc.Write(outputFile);
        }
    }
}

