using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Services.Login
{
    public class StudentLoginService : LoginService<Student>
    {
        public StudentLoginService(IUserRepository<Student> userRepository) : base(userRepository)
        {
        }
    }
}
