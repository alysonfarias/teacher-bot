using Hackathon.Application.DTOS.DeliveryActivity;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IDeliveryActivityService
    {
        Task SendActivity(int studentId, DeliveryActivityRequest deliveryActivityRequest);
    }
}