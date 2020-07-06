using PhDSystem.Core.Constants;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Generators;
using PhDSystem.Core.Generators.Interfaces;
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
            IPhdFileGenerator generator;
            if (documentType == PhdFileType.IndividualPlan)
            {
                var template = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.IndividualPlanWordFileName);
                var data = await _phdFileDataRepository.GetIndividualPlanData(studentId);
                generator = new IndividualPlanGenerator(template, data);
            }
            else if (documentType == PhdFileType.Annotation)
            {
                var template = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.AnnotationWordFileName);
                var data = await _phdFileDataRepository.GetAnnotationData(studentId);
                generator = new AnnotationGenerator(template, data);
            }
            else if (documentType == PhdFileType.Attestation)
            {
                var template = await _fileManager.GetFileAsync(new string[] { FileConstants.TemplatesFolder }, FileConstants.AttestationWordFileName);
                var data = await _phdFileDataRepository.GetAttestationData(studentId, year);
                generator = new AttestationGenerator(template, data);
            }
            else
            {
                throw new NotImplementedException($"Phd File Generator for the given document type - {documentType} is not implemented");
            }

            return generator.GenerateFile();
        }
    }
}
