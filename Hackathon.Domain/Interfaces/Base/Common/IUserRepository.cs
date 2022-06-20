using Hackathon.Domain.Models.Core;

namespace Hackathon.Domain.Interfaces.Base.Common
{
    public interface IUserRepository<UserEntity> : IBaseRepository<UserEntity>
    where UserEntity: User
    {}
}