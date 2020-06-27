using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhdProgramsController : ControllerBase
    {
        private readonly IPhdProgramRepository _phdProgramRepository;

        public PhdProgramsController(IPhdProgramRepository phdProgramRepository)
        {
            _phdProgramRepository = phdProgramRepository;
        }

        [HttpGet("{professionalFieldId}")]
        public async Task<IActionResult> GetFormsOfEducation(int professionalFieldId)
        {
            var phdPrograms = await _phdProgramRepository.GetPhdPrograms(professionalFieldId);
            return Ok(phdPrograms);
        }
    }
}
