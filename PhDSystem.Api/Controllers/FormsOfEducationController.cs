using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/educationForms")]
    [ApiController]
    [Authorize(Roles = "Admin, Student")]
    public class FormsOfEducationController : ControllerBase
    {
        private readonly IFormOfEducationRepository _formOfEducationRepository;

        public FormsOfEducationController(IFormOfEducationRepository formOfEducationRepository)
        {
            _formOfEducationRepository = formOfEducationRepository ?? throw new ArgumentNullException(nameof(formOfEducationRepository)); ;
        }

        [HttpGet()]
        public async Task<IActionResult> GetFormsOfEducation()
        {
            var forms = await _formOfEducationRepository.GetFormsOfEducation();
            return Ok(forms);
        }
    }
}
