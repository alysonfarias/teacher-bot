using AutoMapper;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;
//using Hackathon.Application.Extensions;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.Mappers
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Instructor, InstructorResponse>();
            CreateMap<Student, StudentResponse>();
                //.MergeList(x => x.ClassRooms, vm => vm.ClassRooms);

            CreateMap<UserRole, UserRoleResponse>();
            CreateMap<ClassRoom, ClassRoomResponse>();
        }
    }
}