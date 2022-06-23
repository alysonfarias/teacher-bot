using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Params;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Services
{
    public abstract class UserService<T,Req,Res> : IUserService<T,Req,Res>
    where T: User
    where Req : UserRequest
    where Res: UserResponse
    {
        protected readonly IUserRepository<T> _userRepository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public IValidator<Req> _userRequestValidator {get; set;}
        protected IAuthService _authService;

        public UserService
        (
            IUserRepository<T> userRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IValidator<Req> userRequestValidator,
            IAuthService authService
        )
        {
            _userRequestValidator = userRequestValidator;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;

            _userRepository.AddPreQuery(x => x.Include(x => x.UserRole));
        }

        public async Task<Res> RegisterAsync(Req userRequest)
        {
            var validation = await _userRequestValidator.ValidateAsync(userRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

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

        public IEnumerable<UserRoleResponse> GetUserRoles()
        {
            return _mapper.Map<IEnumerable<UserRoleResponse>>(Enumeration.GetAll<UserRole>());
        }

        public async Task<Res> RemoveAsync(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Usuário com: {id} não existe! ");

            await _userRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Res>(existing);
        }

        public async Task<Res> UpdateAsync(Req userRequest, int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Usuário com: {id} não existe! ");

            _userRepository.AddPreQuery(x => x.Where(u => u.Id != id));
            userRequest.Password = string.IsNullOrEmpty(userRequest.Password) ? existing.Password : PasswordHasher.Hash(userRequest.Password);

            var validation = await _userRequestValidator.ValidateAsync(userRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map(userRequest, existing);
            await _userRepository.UpdateAsync(existing);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<Res>(existing);
        }
    }
}

