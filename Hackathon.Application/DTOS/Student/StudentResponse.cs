using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;

namespace Hackathon.Application.DTOS.Student
{
    public class StudentResponse : UserResponse
    {
        public string ResponsiblePhone { get; set; }
        public IEnumerable<ClassRoomMinimalResponse> ClassRooms { get; set; }
        public UserRoleResponse UserRole { get; set; }
    }
}