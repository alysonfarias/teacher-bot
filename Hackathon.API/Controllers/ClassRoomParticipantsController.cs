using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Roles;
using Hackathon.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{Roles.Student}, {Roles.Admin}")]
    public class ClassRoomParticipantsController : ControllerBase
    {
        public IClassRoomParticipantsService _classRoomParticipantsService { get; set; }
        public IAuthService _authService { get; set; }

        public ClassRoomParticipantsController(IClassRoomParticipantsService classRoomParticipantsService, IAuthService authService)
        {
            _classRoomParticipantsService = classRoomParticipantsService;
            _authService = authService;
        }

        [HttpPost]
        [Route("register-for-classroom/{classRoomId:int}")]
        public async Task<IActionResult> RegisterForClassRoom(int classRoomId)
        {
            await _classRoomParticipantsService.RegisterParticipant(classRoomId, _authService.AuthUser.Id);
            return Ok();
        }
    }
}
