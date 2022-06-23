using Hackathon.Domain.Core.Common;

namespace Hackathon.Domain.Models
{
    public class ClassRoomParticipants : Register
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }

    }
}
