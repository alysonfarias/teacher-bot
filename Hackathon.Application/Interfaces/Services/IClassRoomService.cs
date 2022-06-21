using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.ClassRoom;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IClassRoomService
    {
        Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int id);
        Task<ClassRoomResponse> UpdateAsync(int id, ClassRoomRequest classRoomRequest);
        Task<ClassRoomResponse> DeleteAsync(int id);
        Task<ActivityResponse> RegisterActivityAsync(int classRoomId, int instructorId, ActivityRequest activityRequest);
    }
}