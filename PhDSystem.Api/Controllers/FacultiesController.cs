using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultiesController(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository ?? throw new ArgumentNullException(nameof(facultyRepository)); ;
        }

        [HttpGet("{universityId}")]
        public async Task<IActionResult> GetFaculties(int universityId)
        {
            var faculties = await _facultyRepository.GetFaculties(universityId);
            return Ok(faculties);
        }
    }
}
