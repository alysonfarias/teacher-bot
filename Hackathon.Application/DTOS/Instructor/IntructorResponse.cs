using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;

namespace Hackathon.Application.DTOS.Instructor
{
    public class InstructorResponse : UserResponse
    {
        public UserRoleResponse UserRole { get; set; }
        public SubjectResponse Subject { get; set; }
        IEnumerable<ClassRoomResponse> ClassRooms { get; set; }
    }
}