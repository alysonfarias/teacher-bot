using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Services
{
    public class StudentService : UserService<Student, StudentRequest, StudentResponse>, IStudentService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        public StudentService
        (
            IClassRoomRepository classRoomRepository,
            IUserRepository<Student> userRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IValidator<StudentRequest> userRequestValidator, 
            IAuthService authService
        ) : base(userRepository, mapper, unitOfWork, userRequestValidator, authService)
        {
            _classRoomRepository = classRoomRepository;
            _classRoomRepository.AddPreQuery(x => x
                .Include(x => x.Students));

            _userRepository.AddPreQuery(x => x.Include(x => x.ClassRooms));
        }
       
        public async Task RegisterForClassRoom(int classRoomId, int studentId)
        {
            var student = await _userRepository.GetByIdAsync(studentId);
            if(student.Id != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);
            if(classRoom is null)
                throw new NotFoundException("O id informado não existe");

            var classRooms = student.ClassRooms.ToList();
            classRooms.Add(classRoom);
            student.ClassRooms = classRooms;
           

            var studentsInClassRoom = classRoom.Students.ToList();
            studentsInClassRoom.Add(student);
            classRoom.Students = studentsInClassRoom;

            await _unitOfWork.CommitAsync();
        }
    }
}