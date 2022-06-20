using Hackathon.Domain;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.Repositories
{
    public class AdminRepository : UserRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
