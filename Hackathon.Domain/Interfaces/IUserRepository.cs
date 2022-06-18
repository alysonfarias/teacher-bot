using Hackathon.Domain.Models.Core;

namespace Hackathon.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByName(string username);
    }
}
