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
        
        public LoginService(
            IUserRepository<T> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Claim>> Login(LoginDTO model)
        {
            var user = await _userRepository.GetUserByName(model.Username);

            if (user is null)
                throw new BadRequestException(nameof(model.Username), "Usuário não encontrado");

            if (!PasswordHasher.Verify(model.Password, user.Password))
                throw new BadRequestException(nameof(model.Password), "Senha inválida");

            return new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.UserRole.Name),
                };
        }
    }
}
