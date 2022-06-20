using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Student
{
    public class StudentResponse : UserResponse
    {
        public IEnumerable<string> ResponsiblePhones{ get; set; }
        public IEnumerable<ClassRoomResponse> ClassRooms { get; set; }
    }
}