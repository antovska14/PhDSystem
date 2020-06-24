using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Data.Repositories.Interfaces;

namespace PhDSystem.Api.Controllers
{
    [Route("api/educationForms")]
    [ApiController]
    public class FormsOfEducationController : ControllerBase
    {
        private readonly IFormOfEducationRepository _formOfEducationRepository;

        public FormsOfEducationController(IFormOfEducationRepository formOfEducationRepository)
        {
            _formOfEducationRepository = formOfEducationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFormsOfEducation()
        {
            var forms = await _formOfEducationRepository.GetFormsOfEducation();
            return Ok(forms);
        }
    }
}
