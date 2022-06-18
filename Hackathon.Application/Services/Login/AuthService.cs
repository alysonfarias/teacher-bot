using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Hackathon.Application.Services.Login
{
    public class AuthService : IAuthService
    {
        public AuthUser AuthUser { get; private set; }

        public AuthService(IHttpContextAccessor httpContextAccessor = null)
        {
            if (httpContextAccessor is not null)
                SetLoggedUser(httpContextAccessor.HttpContext.User);
        }

        public void SetLoggedUser(ClaimsPrincipal claims)
        {
            if (!claims.Identity.IsAuthenticated)
                return;

            AuthUser = new AuthUser
            {
                Id = int.Parse(claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value),
                Name = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value,
                //Email = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value,
            };
        }
    }
}
