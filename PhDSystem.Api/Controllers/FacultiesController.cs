using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : CustomBaseController
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultiesController(ILogger logger, IFacultyRepository facultyRepository): base(logger)
        {
            _facultyRepository = facultyRepository;
        }

        [HttpGet("{universityId}")]
        public async Task<IActionResult> GetFaculties(int universityId)
        {
            IEnumerable<Faculty> faculties;
            try
            {
                faculties = await _facultyRepository.GetFaculties(universityId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving faculties for univeristy with id {universityId}", universityId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

            return Ok(faculties);
        }
    }
}
