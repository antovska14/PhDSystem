using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    [Authorize]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.CreateTeacherAsync(teacherDetails);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpDelete("{teacherId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            await _teacherRepository.DeleteTeacherAsync(teacherId);
            return Ok();
        }

        [HttpGet("{teacherId}")]
        [Authorize(Roles = "Admin, Teacher")]
        public async Task<IActionResult> GetTeacher(int teacherId)
        {
            var student = await _teacherRepository.GetTeacherAsync(teacherId);
            return Ok(student);
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherRepository.GetTeachersAsync();
            return Ok(teachers);
        }

        [HttpPut()]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] TeacherDetails teacherDetails)
        {
            await _teacherService.UpdateTeacherAsync(teacherDetails.Id, teacherDetails);
            return Ok();
        }
    }
}
