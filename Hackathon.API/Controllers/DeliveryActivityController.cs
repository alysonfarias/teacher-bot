using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Roles;
using Hackathon.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [ApiController]
    [Authorize(Roles = Roles.Student)]
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
    }
}