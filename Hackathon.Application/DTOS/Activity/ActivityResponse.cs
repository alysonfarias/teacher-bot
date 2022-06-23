using Hackathon.Application.DTOS.Arquive;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Activity
{
    public class ActivityResponse : RegisterViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ClassRoomResponse ClassRoom { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<ArquiveResponse> Arquives { get; set; }
    }
}