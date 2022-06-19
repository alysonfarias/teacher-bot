using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {}
    }
}
