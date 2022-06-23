using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base;

namespace Hackathon.Infrastructure.Repositories
{
    public class DeliveryActivityRepository : BaseRepository<DeliveryActivity>, IDeliveryActivityRepository
    {
        public DeliveryActivityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}