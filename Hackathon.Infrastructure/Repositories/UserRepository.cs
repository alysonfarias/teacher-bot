using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
