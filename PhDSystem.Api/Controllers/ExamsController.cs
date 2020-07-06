using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Models.Exams;
using PhDSystem.Data.Repositories.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamService examService, IExamRepository examRepository)
        {
            _examService = examService;
            _examRepository = examRepository;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetExams(int studentId)
        {
            IEnumerable<ExamsYearDetails> exams = await _examService.GetExams(studentId);
            return Ok(exams);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddExam([FromBody] Exam exam)
        {
            await _examRepository.AddExam(exam);
            return Ok();
        }

        [HttpDelete("{examId}")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            await _examRepository.DeleteExam(examId);
            return Ok();
        }
    }
}
