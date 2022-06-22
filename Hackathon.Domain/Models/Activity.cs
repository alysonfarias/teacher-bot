using Hackathon.Domain.Core.Common;

namespace Hackathon.Domain.Models
{
    public class Activity : Register
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<Arquive> Arquives { get; set; }
        public IEnumerable<Student> StudentPerformers { get; set; }
    }
}
