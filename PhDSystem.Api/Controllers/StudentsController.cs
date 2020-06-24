using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models.Students;
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
        public async Task<IActionResult> CreateStudent([FromBody] StudentUpsertModel studentCreateData)
        {
            await _studentService.CreateStudentAsync(studentCreateData);
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

        [HttpGet("teacher/{teacherId}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetStudentsByTeacherUserId(int teacherUserId)
        {
            var students = await _studentService.GetStudentsByTeacherUserIdAsync(teacherUserId);
            return Ok(students);
        }

        [HttpPut("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] StudentUpsertModel studentUpdateData)
        {
            await _studentService.UpdateStudentAsync(studentUpdateData.Id, studentUpdateData);
            return Ok();
        }
    }
}
