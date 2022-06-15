using Hackathon.Domain.Core.Common;

namespace Hackathon.Domain.Models
{
    public class Activity : Register
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }
        public IEnumerable<File> Files { get; set; }
        public DateTime DueDate { get; set; }
    }
}
