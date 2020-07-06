using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/studentFiles")]
    [Authorize]
    public class StudentFilesController : ControllerBase
    {
        private readonly IStudentFileService _studentFileService;

        public StudentFilesController(IStudentFileService studentFileService)
        {
            _studentFileService = studentFileService ?? throw new ArgumentNullException(nameof(studentFileService)); ;
        }

        [HttpGet("{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> GetStudentFileDetailsList(int studentId)
        {
            var studentFileDetailsList = await _studentFileService.GetStudentFileDetailsList(studentId);
            return Ok(studentFileDetailsList);
        }

        [HttpPost("download/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DownloadStudentFile([FromBody] FileInfoModel file, int studentId)
        {
            var resultFile = await _studentFileService.DownloadStudentFile(file.FileName, studentId);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), resultFile.ContentType, resultFile.FileName);
        }

        [HttpPost("download/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DownloadStudentFileForYear([FromBody] FileInfoModel file, int studentId, int year)
        {
            var resultFile = await _studentFileService.DownloadStudentFile(file.FileName, studentId, year);
            return File(((MemoryStream)resultFile.FileContent).ToArray(), MimeTypes.GetMimeType(resultFile.FileName), resultFile.FileName);
        }

        [HttpPost("upload/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadStudentFile(int studentId)
        {
            var file = Request.Form.Files[0];
            await _studentFileService.UploadStudentFile(file, studentId);

            return Ok();
        }

        [HttpPost("upload/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadStudentFileForYear(int studentId, int year)
        {
            var file = Request.Form.Files[0];
            await _studentFileService.UploadStudentFile(file, studentId, year);

            return Ok();
        }

        [HttpPost("delete/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DeleteStudentFile([FromBody] FileInfoModel fileModel, int studentId)
        {
            await _studentFileService.DeleteStudentFile(fileModel.FileName, studentId);

            return Ok();
        }

        [HttpPost("delete/{studentId}/{year}"), DisableRequestSizeLimit]
        public async Task<IActionResult> DeleteStudentFileForYear([FromBody] FileInfoModel fileModel, int studentId, int year)
        {
            await _studentFileService.DeleteStudentFile(fileModel.FileName, studentId, year);

            return Ok();
        }
    }
}