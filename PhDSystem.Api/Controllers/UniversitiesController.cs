using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/universities")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UniversitiesController : ControllerBase
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversitiesController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository ?? throw new ArgumentNullException(nameof(universityRepository)); ;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUniversities()
        {
            var universities = await _universityRepository.GetUniversities();
            return Ok(universities);
        }
    }
}
