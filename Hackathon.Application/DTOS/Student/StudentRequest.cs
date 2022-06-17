using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Student
{
    public class StudentRequest : UserRequest
    {
        public IEnumerable<string> ResponsiblePhones{ get; set; }
    }
}