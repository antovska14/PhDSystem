using Microsoft.AspNetCore.Mvc;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Models;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Authenticate([FromBody]User user)
        {
            UserAuth userAuth = await _authService.ValidateUser(user);
            if (userAuth != null && userAuth.IsAuthenticated)
            {
                return Ok(userAuth);
            }

            return NotFound("Invalid User Name/Password");
        }
    }
}
