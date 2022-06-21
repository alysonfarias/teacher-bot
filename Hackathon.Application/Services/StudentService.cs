using AutoMapper;
using FluentValidation;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services
{
    public class StudentService : UserService<Student, StudentRequest, StudentResponse>, IStudentService
    {
        public StudentService(IUserRepository<Student> userRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<StudentRequest> userRequestValidator) : base(userRepository, mapper, unitOfWork, userRequestValidator)
        {
        }
    }
}