using Hackathon.Application.DTOS.Auth;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/auth")]
    public class StudentAuthController : ControllerBase
    {
        private readonly ILoginService<Student> _studentLoginService;
        private readonly ITokenGeneratorService _studentTokenGeneratorService;

        public StudentAuthController(ILoginService<Student> loginService, ITokenGeneratorService tokenGeneratorService)
        {
            _studentLoginService = loginService;
            _studentTokenGeneratorService = tokenGeneratorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginDTO request)
        {
            var result = await _studentLoginService.Login(request);
            var token = _studentTokenGeneratorService.GenerateToken(result);

            return Ok(new
            {
                Token = token,
            });
        }
    }
}
