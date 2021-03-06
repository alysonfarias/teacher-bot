using AutoMapper;
using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.Arquive;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.Mappers
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Instructor, InstructorResponse>();

            CreateMap<Student, StudentResponse>();
            CreateMap<Student, StudentMinimalResponse>();

            CreateMap<UserRole, UserRoleResponse>();
            CreateMap<Subject, SubjectResponse>();

            CreateMap<ClassRoom, ClassRoomResponse>();
            CreateMap<ClassRoom, ClassRoomMinimalResponse>();

            CreateMap<Activity, ActivityResponse>();

            CreateMap<Arquive, ArquiveResponse>();
        }
    }
}