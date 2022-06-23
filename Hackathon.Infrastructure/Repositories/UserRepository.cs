using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Infrastructure.Repositories
{
    public class UserRepository<T> : BaseRepository<T>, IUserRepository<T> where T : User
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<T> GetUserByName(string username)
        {
            var user = await base.Query()
                .AsNoTracking()
                .Include(x => x.UserRole)
                .FirstOrDefaultAsync(x => x.Username == username);
            return user;
        }
    }
}
