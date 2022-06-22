namespace Hackathon.Application.Interfaces.Services
{
    public interface IClassRoomParticipantsService
    {
        Task RegisterParticipant (int studentId, int classroomId);
    }
}
