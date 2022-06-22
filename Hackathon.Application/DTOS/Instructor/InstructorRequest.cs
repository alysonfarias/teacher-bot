using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Instructor
{
    public class InstructorRequest : UserRequest
    {
        public int SubjectId { get; set; }
    }
}