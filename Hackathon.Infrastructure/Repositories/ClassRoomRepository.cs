using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base;

namespace Hackathon.Infrastructure.Repositories
{
    public class ClassRoomRepository : BaseRepository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(ApplicationContext context) : base(context)
        {}
    }
}