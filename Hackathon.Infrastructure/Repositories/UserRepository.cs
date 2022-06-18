using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> GetUserByName(string username)
        {
            var user = await base.Query()
                .AsNoTracking()
                .Include(x => x.UserRole)
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }
    }
}
