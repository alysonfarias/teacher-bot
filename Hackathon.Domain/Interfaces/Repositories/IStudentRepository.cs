using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models;

namespace Hackathon.Domain.Interfaces.Repositories
{
    public interface IStudentRepository : IUserRepository<Student>
    {
    }
}