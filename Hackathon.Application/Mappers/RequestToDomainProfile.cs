using AutoMapper;
using Hackathon.Application.Constants;
using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Mappers
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<InstructorRequest, Instructor>()
                .ForMember(x => x.UserRoleId, m => m.MapFrom(req => 2));
            CreateMap<StudentRequest, Student>()
                .ForMember(x => x.UserRoleId, m => m.MapFrom(req => 3));
            CreateMap<ActivityRequest,Activity>();
            CreateMap<ClassRoomRequest, ClassRoom>();
            CreateMap<DeliveryActivityRequest,DeliveryActivity>();
        }
    }
}