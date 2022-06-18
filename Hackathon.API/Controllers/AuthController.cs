using Hackathon.Application.DTOS.Auth;
using Hackathon.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public AuthController(ILoginService loginService, ITokenGeneratorService tokenGeneratorService)
        {
            _loginService = loginService;
            _tokenGeneratorService = tokenGeneratorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginDTO request)
        {
            var result = await _loginService.Login(request);
            var token = _tokenGeneratorService.GenerateToken(result);

            return Ok(new
            {
                Token = token,
            });
        }

    }
}
