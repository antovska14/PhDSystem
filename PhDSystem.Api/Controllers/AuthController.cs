using Microsoft.AspNetCore.Mvc;
using PhDSystem.Api.Models;
using PhDSystem.Api.Services.Interfaces;

namespace PhDSystem.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private IUserInfoService _userInfoService;

        public AuthController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        //Post: api/userinfo/authenticate
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            var user = _userInfoService.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "Username and password incorrect" });
            }

            return Ok(user);
        }
    }
}
