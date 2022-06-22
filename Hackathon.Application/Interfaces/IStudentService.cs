using Hackathon.Application.DTOS.Student;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Interfaces
{
    public interface IStudentService : IUserService<Student, StudentRequest, StudentResponse>
    {
        Task RegisterForClassRoom(int classRoomId, int studentId);
    }
}