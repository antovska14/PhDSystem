using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Api.Managers.Interfaces;

namespace PhDSystem.Api.Controllers
{
    [Route("file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public FileController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("export")]
        public IActionResult ExportFile()
        {
            var resultFileStream = _fileManager.GetIndividualPlan();
            return Ok(File(resultFileStream, "application/octet-stream"));
        }
    }
}