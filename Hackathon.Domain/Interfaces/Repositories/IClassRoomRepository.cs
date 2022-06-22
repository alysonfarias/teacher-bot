using Hackathon.Domain.Interfaces.Base;
using Hackathon.Domain.Models;

namespace Hackathon.Domain.Interfaces.Repositories
{
    public interface IClassRoomRepository : IBaseRepository<ClassRoom>
    {
        Task SendActivity(int activityId, int studentId, string dataBase64);
    }
}