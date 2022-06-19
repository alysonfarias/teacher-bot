using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.Repositories.Base.Common
{
    public abstract class UserRepository<UserEntity> : BaseRepository<UserEntity>, IUserRepository<UserEntity>
    where UserEntity : User
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}