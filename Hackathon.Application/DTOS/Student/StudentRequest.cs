using Hackathon.Application.DTOS.Common;

namespace Hackathon.Application.DTOS.Student
{
    public class StudentRequest : UserRequest
    {
        public string ResponsiblePhone{ get; set; }
    }
}