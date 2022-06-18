using Hackathon.Domain.Models.Core;

namespace Hackathon.Domain.Models
{
    public class Student : User
    {
        public string ResponsiblePhone { get; set; }
        public IEnumerable<ClassRoom> ClassRooms { get; set; }
    }
}
