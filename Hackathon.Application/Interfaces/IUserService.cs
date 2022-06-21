using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;
using Hackathon.Application.Params;
using Hackathon.Domain.Models.Core;

namespace Hackathon.Application.Interfaces
{
    public interface IUserService<T, Req, Res> where T : User where Req : UserRequest
    where Res: UserResponse
    {
        Task<IEnumerable<Res>> GetAsync(UserParams<T> queryParams = null);
        Task<Res> GetByIdAsync(int id);
        IEnumerable<UserRoleResponse> GetUserRoles();
        Task<Res> RegisterAsync(Req userRequest);
        Task<Res> UpdateAsync(Req userRequest, int id);
        Task<Res> RemoveAsync(int id);
    }
}