using AutoMapper;
using Hackathon.Application.DTOS.Common;
using Hackathon.Domain.Models.Core;

namespace Hackathon.Application.Mappers
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<UserRequest, User>();
        }
    }
}