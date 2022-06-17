using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Domain.Models
{
    public class Instructor : User
    {
        public Subject Subject { get; set; }
        public int SubjectId { get; set; }
        public IEnumerable<ClassRoom> Classrooms { get; set; }
    }
}
