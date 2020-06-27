using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("{facultyId}")]
        public async Task<IActionResult> GetFaculties(int facultyId)
        {
            var faculties = await _departmentRepository.GetDepartments(facultyId);
            return Ok(faculties);
        }
    }
}
