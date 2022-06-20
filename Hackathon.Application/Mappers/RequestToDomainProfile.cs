using AutoMapper;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Mappers
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<InstructorRequest,Instructor>();
            CreateMap<StudentRequest,Student>();
        }
    }
}