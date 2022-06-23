
using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.Interfaces.Services;
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
        public IMapper _mapper { get; set; }
        public IValidator<DeliveryActivityRequest> _requestValidator { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public DeliveryActivityService(
            IDeliveryActivityRepository deliveryActivityRepository,
            IStudentRepository studentRepository, 
            IMapper mapper, 
            IValidator<DeliveryActivityRequest> requestValidator, 
            IUnitOfWork unitOfWork)
        {
            _deliveryActivityRepository = deliveryActivityRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _requestValidator = requestValidator;
            _unitOfWork = unitOfWork;

            _studentRepository.AddPreQuery(query => query.Include(st => st.ClassRooms));
        }

        public async Task SendActivity(int studentId, DeliveryActivityRequest deliveryActivityRequest)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if
            ( ! student.ClassRooms
                    .SelectMany(cl => cl.Activities)
                    .Any(at => at.Id == deliveryActivityRequest.ActivityId)
            )
                throw new NotFoundException("O aluno nao contem tal atividade");


            var validationResult = await _requestValidator.ValidateAsync(deliveryActivityRequest);
            if ( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            var deliveryActivity = _mapper.Map<DeliveryActivity>(deliveryActivityRequest);
            deliveryActivity.StudentId = studentId;

            await _deliveryActivityRepository.RegisterAsync(deliveryActivity);
            await _unitOfWork.CommitAsync();
            //Informar para o Instructor que a atividade foi entregue pelo aluno
        }
    }
}