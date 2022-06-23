using Hackathon.Application.DTOS.ClassRoom;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IClassRoomParticipantsService
    {
        Task RegisterParticipant (int studentId, int classroomId);
        Task<IEnumerable<ClassRoomResponse>> GetParticipatingClasses(int studentId);
    }
}
