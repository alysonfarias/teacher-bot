using System.Security.Claims;

namespace Hackathon.Application.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
