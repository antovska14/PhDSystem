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
    public class DepartmentsController : CustomBaseController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(ILogger logger, IDepartmentRepository departmentRepository) : base(logger)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("{facultyId}")]
        public async Task<IActionResult> GetFaculties(int facultyId)
        {
            IEnumerable<Department> faculties;
            try
            {
                faculties = await _departmentRepository.GetDepartments(facultyId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving departments for faculty with id {facultyId}", facultyId);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

            return Ok(faculties);
        }
    }
}
