using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Entities;
using PhDSystem.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetExams(int studentId)
        {
            var exams = await _examRepository.GetExams(studentId);
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
