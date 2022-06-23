using Hackathon.Application.DTOS.Auth;
using Hackathon.Domain.Models.Core;
using System.Security.Claims;

namespace Hackathon.Application.Interfaces
{
    public interface ILoginService<T> where T : User
    {
        Task<IEnumerable<Claim>> Login(LoginDTO model);
    }
}
