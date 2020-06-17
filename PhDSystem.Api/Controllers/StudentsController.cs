using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Core.Services.Models;
using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDetails studentDetails)
        {
            await _studentService.CreateStudentAsync(studentDetails);
            return Ok();
        }

        [HttpDelete("{studentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            await _studentService.DeleteStudentAsync(studentId);
            return Ok();
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            var student = await _studentService.GetStudentAsync(studentId);
            return Ok(student);
        }

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("supervisor/{supervisorId}")]
        [Authorize(Roles = "Supervisor")]
        public async Task<IActionResult> GetStudentsBySupervisor(int supervisorId)
        {
            var students = await _studentService.GetStudentsBySupervisorAsync(supervisorId);
            return Ok(students);
        }

        [HttpPut("{studentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int studentId, [FromBody] StudentDetails studentDetails)
        {
            await _studentService.UpdateStudentAsync(studentId, studentDetails);
            return Ok();
        }
    }
}
