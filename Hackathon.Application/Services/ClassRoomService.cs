using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services
{
    public class ClassRoomService : IClassRoomService
    {
        public IClassRoomRepository _classRoomRepository { get; set; }
        
        public IValidator<ClassRoomRequest> _classRoomValidator { get; set; }
        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }
        
        public ClassRoomService
        (
            IClassRoomRepository classRoomRepository,
            IValidator<ClassRoomRequest> classRoomValidator,
            IMapper mapper,
            IUnitOfWork unitOfWork
        )
        {
            _classRoomRepository = classRoomRepository;
            _classRoomValidator = classRoomValidator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int intructorId)
        {
            var validationResult = await _classRoomValidator.ValidateAsync(classRoomRequest);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var classRoom = _mapper.Map<ClassRoom>(classRoomRequest);
            classRoom.InstructorId = intructorId;
            var classRoomCreated = _classRoomRepository.RegisterAsync(classRoom);

            return _mapper.Map<ClassRoomResponse>(classRoomCreated);
        }
    }
}