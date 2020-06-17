using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAuthService _authService;

        public AuthController(JwtSettings jwtSettings, IAuthService authService)
        {
            _jwtSettings = jwtSettings;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] User request)
        {
            UserAuth userAuth = await _authService.ValidateUserAsync(request);
            if (userAuth != null && userAuth.IsAuthenticated)
            {
                return Ok(userAuth);
            }

            return NotFound("Invalid User Name/Password");
        }
    }
}
