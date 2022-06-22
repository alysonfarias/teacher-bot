using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Params;
using Hackathon.Application.Roles;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = Roles.Instructor)]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IClassRoomService _classRoomService;

        public InstructorController(IInstructorService instructorService, IClassRoomService classRoomService)
        {
            _instructorService = instructorService;
            _classRoomService = classRoomService;
        }

        [HttpGet]
        public async Task<IEnumerable<InstructorResponse>> GetAsync([FromQuery] UserParams<Instructor> queryParams)
        {
            return await _instructorService.GetAsync(queryParams);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InstructorResponse>> GetByIdAsync(int id)
        {
            return await _instructorService.GetByIdAsync(id);
        }

        [HttpGet("{ClassRoomId:int}")]
        public async Task<ActionResult<InstructorResponse>> GetActivitiesInClassRoom(int ClassRoomId)
        {
            return await _classRoomService.
        }

        [HttpPost]
        public async Task<ActionResult<InstructorResponse>> PostAsync([FromBody] InstructorRequest instructor)
        {
            return await _instructorService.RegisterAsync(instructor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<InstructorResponse>> PutAsync([FromBody] InstructorRequest instructor, [FromRoute] int id)
        {
            return await _instructorService.UpdateAsync(instructor, id);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<InstructorResponse>> DeleteAsync(int id)
        {
            return await _instructorService.RemoveAsync(id);
        }

        [HttpGet("user-roles")]
        public IEnumerable<UserRoleResponse> GetUserRoles()
        {
            return _instructorService.GetUserRoles();
        }
    }
}