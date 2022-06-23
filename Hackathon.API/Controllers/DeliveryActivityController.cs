using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Params;
using Hackathon.Application.Roles;
using Hackathon.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class DeliveryActivityController : ControllerBase
    {
        public IDeliveryActivityService _deliveryActivityService  { get; set; }
        public IAuthService _authService { get; set; }

        public DeliveryActivityController(IDeliveryActivityService deliveryActivityService, IAuthService authService)
        {
            _deliveryActivityService = deliveryActivityService;
            _authService = authService;
        }

        [HttpPost]
        [Authorize(Roles = Roles.Student)] 

        public async Task<ActionResult> RegisterAsync([FromBody] DeliveryActivityRequest deliveryActivityRequest)
        {
            await _deliveryActivityService.SendActivity(_authService.AuthUser.Id, deliveryActivityRequest);
            return NoContent();
        }

        [HttpGet]
        [Route("/[action]/{activityId:int}")]
        [Authorize(Roles = $"{Roles.Instructor}, {Roles.Admin}")]
        public async Task<IEnumerable<StudentMinimalResponse>> GetStudentsByActivity(DeliveryActivityParams deliveryActivityParams)
        {
            var studentResponses = await _deliveryActivityService.GetStudentsByActivity(deliveryActivityParams,_authService.AuthUser.Id);
            return studentResponses;
        }
    }
}