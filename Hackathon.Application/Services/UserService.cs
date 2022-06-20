using AutoMapper;
using FluentValidation;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.Params;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Utils;

namespace Hackathon.Application.Services
{
    public abstract class UserService<T,Req,Res>
    where T: User
    where Req : UserRequest
    where Res: UserResponse
    {
        private readonly IUserRepository<T> _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public IValidator<Req> _userRequestValidator {get; set;}

        public UserService
        (
            IUserRepository<T> userRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IValidator<Req> userRequestValidator
        )
        {
            _userRequestValidator = userRequestValidator;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Res> RegisterAsync(Req userRequest)
        {
            /*var validation = await _validator.ValidateAsync(userRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);*/

            T user = _mapper.Map<T>(userRequest);
            user.Password = PasswordHasher.Hash(userRequest.Password);
            await _userRepository.RegisterAsync(user);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Res>(user);
        }

        public async Task<IEnumerable<Res>> GetAsync(UserParams<T> queryParams = null)
        {
            return _mapper.Map<IEnumerable<Res>>(await _userRepository.GetAllAsync(queryParams.Filter()));
        }

        public async Task<Res> GetByIdAsync(int id)
        {
            return _mapper.Map<Res>(await _userRepository.GetByIdAsync(id));
        }

        public IEnumerable<Res> GetUserRoles()
        {
            return _mapper.Map<IEnumerable<Res>>(Enumeration.GetAll<UserRole>());
        }

        public async Task<Res> RemoveAsync(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"User with Id: {id} does not exists! ");

            await _userRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Res>(existing);
        }

        public async Task<Res> UpdateAsync(Req userRequest, int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"User with Id: {id} does not exists! ");

            _userRepository.AddPreQuery(x => x.Where(u => u.Id != id));
            userRequest.Password = string.IsNullOrEmpty(userRequest.Password) ? existing.Password : PasswordHasher.Hash(userRequest.Password);

            /*var validation = await _validator.ValidateAsync(userRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);*/

            _mapper.Map(userRequest, existing);
            await _userRepository.UpdateAsync(existing);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<Res>(existing);
        }
    }
}
