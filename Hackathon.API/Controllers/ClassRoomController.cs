using Hackathon.Application.DTOS.Activity;
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
    [Authorize(Roles = $"{Roles.Instructor}, {Roles.Admin}" )]
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

        [HttpPost]
        [Route("{id}/activity")]
        public async Task<ActionResult<ActivityResponse>> RegisterActivityAsync(int id ,[FromBody] ActivityRequest activityRequest)
        {
            //foreach (var file in files)
            //{
            //    if (file.Length > 0)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            file.CopyTo(ms);
            //            var fileBytes = ms.ToArray();
            //            string s = Convert.ToBase64String(fileBytes);
            //            // act on the Base64 data
            //            Console.WriteLine(s);
            //        }
            //    }
            //}
            var activityResponse = await _classRoomService.RegisterActivityAsync(id,_authService.AuthUser.Id,activityRequest);
            return Ok(activityRequest);
        }
    
        [HttpPut]
        [Route("{classRoomId:int}/activity/{activityId:int}")]
        public async Task<ActionResult<ActivityResponse>> UpdateActivityAsync(int classRoomId,int activityId,[FromBody] ActivityRequest activityRequest)
        {
            var activityResponse = await _classRoomService.UpdateActivityAsync(classRoomId,activityId,_authService.AuthUser.Id,activityRequest);
            return Ok(activityResponse);
        }

        [HttpDelete]
        [Route("{classRoomId:int}/activity/{activityId:int}")]
        public async Task<ActionResult<ActivityResponse>> DeleteActivityAsync(int classRoomId,int activityId)
        {
            var activityResponse = await _classRoomService.DeleteActivityAsync(classRoomId,activityId,_authService.AuthUser.Id);
            return Ok(activityResponse);
        }


    }
}