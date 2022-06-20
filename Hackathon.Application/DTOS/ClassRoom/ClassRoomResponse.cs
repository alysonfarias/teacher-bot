

using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;

namespace Hackathon.Application.DTOS.ClassRoom
{
    public class ClassRoomResponse : RegisterViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public InstructorResponse Instructor { get; set; }
        public IEnumerable<StudentResponse> Students { get; set; }
        public IEnumerable<ActivityResponse> Activities { get; set; }
    }
}