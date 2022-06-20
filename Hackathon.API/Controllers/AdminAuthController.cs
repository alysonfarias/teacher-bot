using Hackathon.Application.DTOS.Auth;
using Hackathon.Application.Interfaces;
using Hackathon.Domain;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/auth")]
    public class AdminAuthController : ControllerBase
    {
        private readonly ILoginService<Admin> _adminLoginService;
        private readonly ITokenGeneratorService _adminTokenGeneratorService;

        public AdminAuthController(ILoginService<Admin> loginService, ITokenGeneratorService tokenGeneratorService)
        {
            _adminLoginService = loginService;
            _adminTokenGeneratorService = tokenGeneratorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginDTO request)
        {
            var result = await _adminLoginService.Login(request);
            var token = _adminTokenGeneratorService.GenerateToken(result);

            return Ok(new
            {
                Token = token,
            });
        }

    }
}
