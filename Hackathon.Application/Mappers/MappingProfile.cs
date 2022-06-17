using AutoMapper;
using Hackathon.Application.DTOS.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<UserRole, UserRoleResponse>();
        }
    }
}
