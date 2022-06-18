using AutoMapper;
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.Params;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Utils;

namespace Hackathon.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> RegisterAsync(UserRequest userRequest)
        {
            /*var validation = await _validator.ValidateAsync(userRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);*/

            var user = _mapper.Map<User>(userRequest);
            user.Password = PasswordHasher.Hash(userRequest.Password);
            await _userRepository.RegisterAsync(user);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAsync(UserParams queryParams = null)
        {
            return _mapper.Map<IEnumerable<UserResponse>>(await _userRepository.GetAllAsync(queryParams.Filter()));
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<UserResponse>(await _userRepository.GetByIdAsync(id));
        }

        public IEnumerable<UserRoleResponse> GetUserRoles()
        {
            return _mapper.Map<IEnumerable<UserRoleResponse>>(Enumeration.GetAll<UserRole>());
        }

        public async Task<UserResponse> RemoveAsync(int id)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"User with Id: {id} does not exists! ");

            await _userRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserResponse>(existing);
        }

        public async Task<UserResponse> UpdateAsync(UserRequest userRequest, int id)
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
            return _mapper.Map<UserResponse>(existing);
        }
    }
}
