using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Roles;
using Hackathon.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Instructor)]
    public class ClassRoomController : ControllerBase
    {
        public IClassRoomService _classRoomService { get; set; }
        public IAuthService _authService {get;set;}

        public ClassRoomController
        (
            IClassRoomService classRoomService, 
            IAuthService authService
        )
        {
            _classRoomService = classRoomService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<ClassRoomResponse>> RegisterAsync([FromBody] ClassRoomRequest classRoomRequest)
        {
            var classRoomResponse = await _classRoomService.RegisterAsync(classRoomRequest,_authService.AuthUser.Id);
            return Ok(classRoomResponse);
        }
    
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<ClassRoomResponse>> UpdateAsync(int id ,[FromBody] ClassRoomRequest classRoomRequest)
        {
            var classRoomResponse = await _classRoomService.UpdateAsync(id,classRoomRequest);
            return Ok(classRoomResponse);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<ClassRoomResponse>> DeleteAsync(int id)
        {
            var classRoomResponse = await _classRoomService.DeleteAsync(id);
            return Ok(classRoomResponse);
        }
    
    }
}