using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Instructor
{
    public class InstructorRequest :UserViewModel
    {
        public int SubjectId { get; set; }
    }
}