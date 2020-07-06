using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ProfessionalFieldsController : ControllerBase
    {
        private readonly IProfessionalFieldRepository _professionalFieldRepository;

        public ProfessionalFieldsController(IProfessionalFieldRepository professionalFieldRepository)
        {
            _professionalFieldRepository = professionalFieldRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessionalFields()
        {
            var professionalFields = await _professionalFieldRepository.GetProfessionalFields();
            return Ok(professionalFields);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProfessionalField([FromBody] ProfessionalField professionalField)
        {
            await _professionalFieldRepository.AddProfessionalField(professionalField);
            return Ok();
        }
    }
}
