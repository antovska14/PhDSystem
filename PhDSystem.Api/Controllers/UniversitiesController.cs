using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhDSystem.Data;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : CustomBaseController
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversitiesController(ILogger logger, IUniversityRepository universityRepository): base(logger)
        {
            _universityRepository = universityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUniversities()
        {
            IEnumerable<University> universities;
            try
            {
                universities = await _universityRepository.GetUniversities();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving universities");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

            return Ok(universities);
        }
    }
}
