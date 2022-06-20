using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base.Common;

namespace Hackathon.Infrastructure.Repositories
{
    public class StudentRepository : UserRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}