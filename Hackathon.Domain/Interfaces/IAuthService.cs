using Hackathon.Domain.Models;
using System.Security.Claims;

namespace Hackathon.Domain.Interfaces
{
    public interface IAuthService
    {
        void SetLoggedUser(ClaimsPrincipal claims);
        AuthUser AuthUser { get; }
    }
}
