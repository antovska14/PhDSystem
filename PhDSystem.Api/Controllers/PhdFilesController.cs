using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/phdFiles")]
    [ApiController]
    [Authorize]
    public class PhdFilesController : ControllerBase
    {
        private readonly IPhdFileService _phdFileExportService;

        public PhdFilesController(IPhdFileService phdFileExportService)
        {
            _phdFileExportService = phdFileExportService ?? throw new ArgumentNullException(nameof(phdFileExportService)); ;
        }

        [HttpGet("generate/{studentId}/{documentType}/"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFile(int studentId, int year, int documentType)
        {
            var resultFile = await _phdFileExportService.ExportStudentFile((PhdFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpGet("generate/{studentId}/{documentType}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFileForYear(int studentId, int documentType, int year)
        {
            var resultFile = await _phdFileExportService.ExportStudentFile((PhdFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }
    }
}
