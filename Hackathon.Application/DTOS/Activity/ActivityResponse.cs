using Hackathon.Application.DTOS.Arquive;
using Hackathon.Application.DTOS.ClassRoom;

namespace Hackathon.Application.DTOS.Activity
{
    public class ActivityResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ClassRoomResponse ClassRoom { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<ArquiveResponse> Arquives { get; set; }
    }
}