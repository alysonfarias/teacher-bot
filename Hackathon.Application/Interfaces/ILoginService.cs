using Hackathon.Application.DTOS.Auth;
using System.Security.Claims;

namespace Hackathon.Application.Interfaces
{
    public interface ILoginService
    {
        Task<IEnumerable<Claim>> Login(LoginDTO model);
    }
}
