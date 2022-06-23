using Hackathon.Application.DTOS.Auth;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/auth")]
    public class InstructorAuthController : ControllerBase
    {
        private readonly ILoginService<Instructor> _instructorLoginService;
        private readonly ITokenGeneratorService _instructorTokenGeneratorService;

        public InstructorAuthController(ILoginService<Instructor> loginService, ITokenGeneratorService tokenGeneratorService)
        {
            _instructorLoginService = loginService;
            _instructorTokenGeneratorService = tokenGeneratorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginDTO request)
        {
            var result = await _instructorLoginService.Login(request);
            var token = _instructorTokenGeneratorService.GenerateToken(result);

            return Ok(new
            {
                Token = token,
            });
        }
    }
}
