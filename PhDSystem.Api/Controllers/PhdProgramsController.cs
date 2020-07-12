using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/phdPrograms")]
    [ApiController]
    [Authorize]
    public class PhdProgramsController : ControllerBase
    {
        private readonly IPhdProgramRepository _phdProgramRepository;

        public PhdProgramsController(IPhdProgramRepository phdProgramRepository)
        {
            _phdProgramRepository = phdProgramRepository ?? throw new ArgumentNullException(nameof(phdProgramRepository)); ;
        }

        [HttpGet()]
        [Authorize(Roles = "Admin, Student")]
        public async Task<IActionResult> GetPhdPrograms()
        {
            var phdPrograms = await _phdProgramRepository.GetPhdPrograms();
            return Ok(phdPrograms);        }

        [HttpGet("{professionalFieldId}")]
        public async Task<IActionResult> GetPhdPrograms(int professionalFieldId)
        {
            var phdPrograms = await _phdProgramRepository.GetPhdPrograms(professionalFieldId);
            return Ok(phdPrograms);
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProfessionalField([FromBody] PhdProgram phdProgram)
        {
            await _phdProgramRepository.AddPhdProgram(phdProgram);
            return Ok();
        }
    }
}
