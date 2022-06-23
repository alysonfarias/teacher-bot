using AutoMapper;
using FluentValidation;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services
{
    public class InstructorService : UserService<Instructor, InstructorRequest, InstructorResponse>, IInstructorService
    {
        public InstructorService
        (
            IUserRepository<Instructor> userRepository, 
            IMapper mapper, IUnitOfWork unitOfWork, 
            IValidator<InstructorRequest> userRequestValidator, 
            IAuthService authService
        ) : base(userRepository, mapper, unitOfWork, userRequestValidator, authService)
        {
        }
    }
}