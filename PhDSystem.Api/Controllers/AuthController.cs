using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhDSystem.Api.Models;
using PhDSystem.Api.Services.Interfaces;
using PhDSystem.Core.Models;
using PhDSystem.Core.Services.Interfaces;
using PhDSystem.Data.Entities;
using System;
using System.Threading.Tasks;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] User request)
        {
            UserAuth userAuth = await _authService.ValidateUserAsync(request);
            if (userAuth != null && userAuth.IsAuthenticated)
            {
                return Ok(userAuth);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost("setPassword")]
        public async Task<IActionResult> SetPassword([FromBody] SetPasswordModel passwordModel)
        {
            await _userService.SetPassword(passwordModel);
            return Ok();
        }
    }
}
