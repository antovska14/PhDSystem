using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.CreateTeacherAsync(teacherDetails);
            return Ok();
        }

        [HttpDelete("{teacherId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            await _teacherService.DeleteTeacherAsync(teacherId);
            return Ok();
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacher(int teacherId)
        {
            var student = await _teacherService.GetTeacherAsync(teacherId);
            return Ok(student);
        }

        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachersAsync();
            return Ok(teachers);
        }

        [HttpPut("{teacherId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int teacherId, [FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.UpdateTeacherAsync(teacherId, teacherDetails);
            return Ok();
        }
    }
}
