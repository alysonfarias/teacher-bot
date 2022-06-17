using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.ClassRoom
{
    public class ClassRoomRequest : RegisterViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}