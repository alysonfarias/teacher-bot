using AutoMapper;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.Mappers
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRole, UserRoleResponse>();
        }
    }
}