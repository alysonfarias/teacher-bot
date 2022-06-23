using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Params;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Services
{
    public class DeliveryActivityService : IDeliveryActivityService
    {
        public IDeliveryActivityRepository _deliveryActivityRepository { get; set; }
        public IStudentRepository _studentRepository { get; set; }        
        public IClassRoomRepository _classRoomRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IValidator<DeliveryActivityRequest> _requestValidator { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public DeliveryActivityService(
            IDeliveryActivityRepository deliveryActivityRepository,
            IStudentRepository studentRepository, 
            IClassRoomRepository classRoomRepository,
            IMapper mapper, 
            IValidator<DeliveryActivityRequest> requestValidator, 
            IUnitOfWork unitOfWork)
        {
            _deliveryActivityRepository = deliveryActivityRepository;
            _studentRepository = studentRepository;
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _requestValidator = requestValidator;
            _unitOfWork = unitOfWork;

            _deliveryActivityRepository.AddPreQuery(query => query.Include(da => da.Student));
        }

        public async Task SendActivity(int studentId, DeliveryActivityRequest deliveryActivityRequest)
        {
            _studentRepository.AddPreQuery(query => query.Include(st => st.ClassRooms));
            var student = await _studentRepository.GetByIdAsync(studentId);
            if
            ( ! student.ClassRooms
                    .SelectMany(cl => cl.Activities)
                    .Any(at => at.Id == deliveryActivityRequest.ActivityId)
            )
                throw new NotFoundException("O aluno não contém tal atividade");


            var validationResult = await _requestValidator.ValidateAsync(deliveryActivityRequest);
            if ( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var deliveryActivity = _mapper.Map<DeliveryActivity>(deliveryActivityRequest);
            deliveryActivity.StudentId = studentId;

            await _deliveryActivityRepository.RegisterAsync(deliveryActivity);
            await _unitOfWork.CommitAsync();
            //Informar para o Instructor que a atividade foi entregue pelo aluno
        }

        public async Task<IEnumerable<StudentMinimalResponse>> GetStudentsByActivity(DeliveryActivityParams deliveryActivityParams, int instructorId)
        {
            var activityId = deliveryActivityParams.ActivityId;
            if ( activityId is null)
                throw new NotAuthorizedException();
            
            _classRoomRepository.AddPreQuery(query => query.Include(cl => cl.Activities));
            var classRoom = await _classRoomRepository
                .Query()
                .SingleOrDefaultAsync(cl => cl.Activities.Any(at => at.Id ==activityId ));

            if(classRoom is null)
                throw new NotFoundException("Essa atividade não existe");

            if (classRoom.InstructorId != instructorId)
                throw new NotAuthorizedException();
            
            var studentsByActivityMade = await _deliveryActivityRepository
                .GetAllAsync(deliveryActivityParams.Filter());
                
            return _mapper.Map<IEnumerable<StudentMinimalResponse>>(
                studentsByActivityMade.Select(sa => sa.Student)
            );    
        }
    }
}