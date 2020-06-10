using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PhDSystem.Api.Models.IndividualPlans.Request;
using PhDSystem.Api.Models.Students;
using PhDSystem.Api.Models.Teachers;
using PhDSystem.Api.Services.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("file")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [Route("export")]
        public async Task<IActionResult> ExportFile()
        {
            var request = new IndividualPlanRequestModel
            {
                Student = new Student
                {
                    FirstName = "StudentFirstName",
                    MiddleName = null,
                    LastName = "StudentLastName",
                    Title = null
                },
                Supervisor = new Teacher { 
                    FirstName = "SupervisorFisrtName",
                    MiddleName = null,
                    LastName = "SupervisorLastName",
                    Title = "SupervisorTitle"
                },
                Dean = new Teacher
                {
                    FirstName = "DeanFisrtName",
                    MiddleName = null,
                    LastName = "DeanLastName",
                    Title = "DeanTitle"
                },
                Theme = "Theme"
            };

            var result = await _documentService.GetIndividualPlan(request);
            var response = File(((MemoryStream)result.FileContent).ToArray(), MimeTypes.GetMimeType(result.FileName), result.FileName);
            return response;
        }
    }
}