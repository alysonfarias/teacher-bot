using Hackathon.Domain.Models;
using LinqKit;
using System.Linq.Expressions;

namespace Hackathon.Application.Params
{
    public class ClassRoomParams : BaseParams<ClassRoom>
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public override Expression<Func<ClassRoom, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<ClassRoom>(true);

            if (!string.IsNullOrEmpty(Name))
                predicate = predicate.And(x => x.Name.Contains(Name));

            if (InstructorId != 0)
                predicate = predicate.And(x => x.Instructor.Id == InstructorId);

            return predicate;
        }
    }
}
