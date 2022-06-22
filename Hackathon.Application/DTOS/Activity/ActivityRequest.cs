using Hackathon.Application.DTOS.Arquive;
using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Activity
{
    public class ActivityRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClassRoomId { get; set; }
        public DateTime DueDate { get; set; }
        public IEnumerable<ArquiveRequest> Arquives { get; set; }
        
    }
}