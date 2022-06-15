using Hackathon.Domain.Core.Common;

namespace Hackathon.Domain.Models
{
    public class ClassRoom : Register
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public IEnumerable<StudentClassRoom> Students { get; set; }
        public IEnumerable<Activity> Activities { get; set; }
    }
}
