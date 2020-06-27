using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversitiesController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUniversities()
        {
            var universities = await _universityRepository.GetUniversities();
            return Ok(universities);
        }
    }
}
