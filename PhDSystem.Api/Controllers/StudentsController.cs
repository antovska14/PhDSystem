using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            await _studentService.AddStudentAsync(student);
            return Ok();
        }

        [HttpDelete("{studentId}")]
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

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }

        [HttpGet("supervisor/{supervisorId}")]
        public async Task<IActionResult> GetStudentsBySupervisor(int supervisorId)
        {
            var students = await _studentService.GetStudentsBySupervisorAsync(supervisorId);
            return Ok(students);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> Put(int studentId, [FromBody] Student student)
        {
            await _studentService.UpdateStudentAsync(studentId, student);
            return Ok();
        }
    }
}
