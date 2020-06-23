using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhdFilesController : ControllerBase
    {
        private readonly IPhdFileService _phdFileExportService;

        public PhdFilesController(IPhdFileService phdFileExportService)
        {
            _phdFileExportService = phdFileExportService;
        }

        [HttpGet("export/{studentId}/{documentType}/"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFile(int studentId, int year, int documentType)
        {
            var resultFile = await _phdFileExportService.ExportStudentFile((PhdFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpGet("export/{studentId}/{documentType}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFileForYear(int studentId, int documentType, int year)
        {
            var resultFile = await _phdFileExportService.ExportStudentFile((PhdFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }
    }
}
