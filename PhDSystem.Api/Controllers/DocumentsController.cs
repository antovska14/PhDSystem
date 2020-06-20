using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Core.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportFile()
        {
            var result = await _documentService.GetIndividualPlan();
            var response = File(((MemoryStream)result.FileContent).ToArray(), MimeTypes.GetMimeType(result.FileName), result.FileName);
            return response;
        }

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                await _documentService.FileUpload(file);
            }
            catch(Exception e)
            {
                return StatusCode(500, $"Internal Server error: {e}");
            }

            return Ok();
        }

        [HttpPost("upload/{studentId}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFileForStudent(int studentId)
        {
            try
            {
                var file = Request.Form.Files[0];
                await _documentService.StudentFileUpload(studentId, file);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server error: {e}");
            }

            return Ok();
        }

        [HttpDelete("delete/{studentId}"), DisableRequestSizeLimit]
        public IActionResult DeleteFileForStudent([FromBody] TemporaryFileModel fileModel, int studentId)
        {
            _documentService.DeleteStudentFile(studentId, fileModel.FileName);

            return Ok();
        }
    }
}