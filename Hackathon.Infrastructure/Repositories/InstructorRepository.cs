using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base.Common;

namespace Hackathon.Infrastructure.Repositories
{
    public class InstructorRepository : UserRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}