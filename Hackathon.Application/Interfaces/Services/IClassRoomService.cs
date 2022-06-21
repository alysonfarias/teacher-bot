using Hackathon.Application.DTOS.ClassRoom;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IClassRoomService
    {
        Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int id);
        Task<ClassRoomResponse> UpdateAsync(int id, ClassRoomRequest classRoomRequest);
    }
}