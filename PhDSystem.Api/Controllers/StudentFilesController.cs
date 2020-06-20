using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Core.Enums;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentFilesController : ControllerBase
    {
        private readonly IStudentFileService _documentService;

        public StudentFilesController(IStudentFileService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("export/{studentId}/{documentType}/"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFile(int studentId, int year, int documentType)
        {
            var resultFile = await _documentService.ExportStudentFile((StudentFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpGet("export/{studentId}/{documentType}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> ExportStudentFileForYear(int studentId, int documentType, int year)
        {
            var resultFile = await _documentService.ExportStudentFile((StudentFileType)documentType, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpPost("download/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DownloadStudentFile([FromBody] FileInfoModel file, int studentId)
        {
            var resultFile = await _documentService.DownloadStudentFile(file.FileName, studentId);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpPost("download/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DownloadStudentFileForYear([FromBody] FileInfoModel file, int studentId, int year)
        {
            var resultFile = await _documentService.DownloadStudentFile(file.FileName, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpPost("upload/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadStudentFile(int studentId)
        {
            var file = Request.Form.Files[0];
            await _documentService.UploadStudentFile(file, studentId);

            return Ok();
        }

        [HttpPost("upload/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadStudentFileForYear(int studentId, int year)
        {
            var file = Request.Form.Files[0];
            await _documentService.UploadStudentFile(file, studentId, year);

            return Ok();
        }

        [HttpDelete("delete/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DeleteStudentFile([FromBody] FileInfoModel fileModel, int studentId)
        {
            await _documentService.DeleteStudentFile(fileModel.FileName, studentId);

            return Ok();
        }

        [HttpDelete("delete/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DeleteStudentFileForYear([FromBody] FileInfoModel fileModel, int studentId, int year)
        {
            await _documentService.DeleteStudentFile(fileModel.FileName, studentId, year);

            return Ok();
        }
    }
}