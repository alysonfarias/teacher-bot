using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.Auth;
using Hackathon.Application.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Utils;
using System.Security.Claims;

namespace Hackathon.Application.Services.Login
{
    public class LoginService<T> : ILoginService<T> where T : User
    {
        private readonly IUserRepository<T> _userRepository;
        //private readonly IValidator<LoginDTO> _validator;

        public LoginService(
            IUserRepository<T> userRepository)
        {
            _userRepository = userRepository;
            //_validator = validator;
        }

        public async Task<IEnumerable<Claim>> Login(LoginDTO model)
        {
            //var validation = await _validator.ValidateAsync(model);
            //if (!validation.IsValid)
            //    throw new BadRequestException(validation);

            var user = await _userRepository.GetUserByName(model.Username);

            if (user is null)
                throw new BadRequestException(nameof(model.Username), "User not found");

            if (!PasswordHasher.Verify(model.Password, user.Password))
                throw new BadRequestException(nameof(model.Password), "Invalid password");

            return new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.UserRole.Name),
                };
        }
    }
}
