using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    [Authorize(Roles = "Admin")]
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherService teacherService, ITeacherRepository teacherRepository)
        {
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService)); ;
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository)); ;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.CreateTeacherAsync(teacherDetails);
            return Ok();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            await _teacherRepository.DeleteTeacherAsync(teacherId);
            return Ok();
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacher(int teacherId)
        {
            var student = await _teacherRepository.GetTeacherAsync(teacherId);
            return Ok(student);
        }

        [HttpGet()]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherRepository.GetTeachersAsync();
            return Ok(teachers);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.UpdateTeacherAsync(teacherDetails.Id, teacherDetails);
            return Ok();
        }
    }
}
