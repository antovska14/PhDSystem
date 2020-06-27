using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalFieldsController : ControllerBase
    {
        private readonly IProfessionalFieldRepository _professionalFieldRepository;

        public ProfessionalFieldsController(IProfessionalFieldRepository professionalFieldRepository)
        {
            _professionalFieldRepository = professionalFieldRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormsOfEducation()
        {
            var professionalFields = await _professionalFieldRepository.GetProfessionalFields();
            return Ok(professionalFields);
        }
    }
}
