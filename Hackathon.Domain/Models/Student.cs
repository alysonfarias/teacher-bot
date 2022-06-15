using Hackathon.Domain.Core;

namespace Hackathon.Domain.Core.Common
{
    public class Student : User
    {
        public IEnumerable<string> ResponsiblePhones{ get; set; }
        public IEnumerable<StudentClassRoom> ClassRooms { get; set; }

    }
}
