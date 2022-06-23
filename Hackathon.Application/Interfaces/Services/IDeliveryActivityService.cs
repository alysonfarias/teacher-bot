using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Params;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IDeliveryActivityService
    {
        Task SendActivity(int studentId, DeliveryActivityRequest deliveryActivityRequest);
        Task<IEnumerable<StudentMinimalResponse>> GetStudentsByActivity(DeliveryActivityParams deliveryActivityParams, int id);
    }
}