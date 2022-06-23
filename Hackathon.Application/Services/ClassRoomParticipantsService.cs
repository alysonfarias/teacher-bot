using AutoMapper;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services
{
    public class ClassRoomParticipantsService : IClassRoomParticipantsService
    {
        public IClassRoomParticipantsRepository _classRoomParticipantsRepository { get; set; }
        public IClassRoomRepository _classRoomRepository { get; set; }
        public IStudentRepository _studentRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public ClassRoomParticipantsService(IClassRoomParticipantsRepository classRoomParticipantsRepository,
            IStudentRepository studentRepository,
            IClassRoomRepository classRoom,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _classRoomParticipantsRepository = classRoomParticipantsRepository;
            _classRoomRepository = classRoom;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterParticipant(int classRoomId, int studentId)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);
            if(classRoom is null) 
                throw new NotFoundException("Sala não encontrada");

            var classRoomParticipant = new ClassRoomParticipants
            {
                ClassRoomId = classRoomId,
                StudentId = studentId
            };

            await _classRoomParticipantsRepository.RegisterAsync(classRoomParticipant);
            await _unitOfWork.CommitAsync();
        }
    }
}
