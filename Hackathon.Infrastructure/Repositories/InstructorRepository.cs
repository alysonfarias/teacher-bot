using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.Repositories
{
    public class InstructorRepository : UserRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}