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

        public async Task SendActivity(int activityId, int studentId, string dataBase64)
        {
            
            await _context.Set<StudentActivity>().AddAsync(
                new StudentActivity{
                    DataBase64 = dataBase64,
                    StudentId = studentId,
                    ActivityId = activityId
                }
            );
        }
    }
}