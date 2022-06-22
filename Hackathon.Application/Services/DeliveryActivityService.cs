
using AutoMapper;
using Hackathon.Application.DTOS.DeliveryActivity;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services
{
    public class DeliveryActivityService : IDeliveryActivityService
    {
        public IDeliveryActivityRepository _deliveryActivityRepository { get; set; }
        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public DeliveryActivityService(IDeliveryActivityRepository deliveryActivityRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _deliveryActivityRepository = deliveryActivityRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task SendActivity(int studentId, DeliveryActivityRequest deliveryActivityRequest)
        {
            //Validar as regras de negocio
            //Validar a request

            var deliveryActivity = _mapper.Map<DeliveryActivity>(deliveryActivityRequest);
            deliveryActivity.StudentId = studentId;

            await _deliveryActivityRepository.RegisterAsync(deliveryActivity);
            await _unitOfWork.CommitAsync();
            //Informar para o Instructor que a atividade foi entregue pelo aluno
        }
    }
}