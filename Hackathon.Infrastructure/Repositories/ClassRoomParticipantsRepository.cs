using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories.Base;

namespace Hackathon.Infrastructure.Repositories
{
    public class ClassRoomParticipantsRepository : BaseRepository<ClassRoomParticipants>, IClassRoomParticipantsRepository
    {
        public ClassRoomParticipantsRepository(ApplicationContext context) : base(context)
    { }
}
}
