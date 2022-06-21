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
        public IAuthService _authService {get;set;}
        
        public ClassRoomService
        (
            IClassRoomRepository classRoomRepository,
            IValidator<ClassRoomRequest> classRoomValidator,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthService authService 
        )
        {
            _classRoomRepository = classRoomRepository;
            _classRoomValidator = classRoomValidator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int intructorId)
        {
            var validationResult = await _classRoomValidator.ValidateAsync(classRoomRequest);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var classRoom = _mapper.Map<ClassRoom>(classRoomRequest);
            classRoom.InstructorId = intructorId;
            
            var classRoomCreated = _classRoomRepository.RegisterAsync(classRoom);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ClassRoomResponse>(classRoomCreated);
        }

        public async Task<ClassRoomResponse> UpdateAsync(int id, ClassRoomRequest classRoomRequest)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(id);
            if(classRoom is null)
                throw new NotFoundException("O id informado não existe");   
        
            if(classRoom.InstructorId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            _classRoomRepository.AddPreQuery(query => query.Where(cl=>cl.InstructorId != _authService.AuthUser.Id) );
            var validationResult = await _classRoomValidator.ValidateAsync(classRoomRequest);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            _mapper.Map(classRoomRequest,classRoom);

            var classRoomUpdated =  await _classRoomRepository.UpdateAsync(classRoom);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ClassRoomResponse>(classRoom);
        }

        public async Task<ClassRoomResponse> DeleteAsync(int id)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(id);
            if (classRoom is null)
                throw new NotFoundException("O id informado não existe");
        
            if(classRoom.InstructorId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            var classRoomDeleted = await _classRoomRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            
            return _mapper.Map<ClassRoomResponse>(classRoom);  
        }
    }
}