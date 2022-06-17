using Hackathon.Domain.Core;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Core;

namespace Hackathon.Domain.Core.Common
{
    public class Student : User
    {
        public IEnumerable<string> ResponsiblePhones{ get; set; }
        public IEnumerable<ClassRoom> ClassRooms { get; set; }
    }
}
