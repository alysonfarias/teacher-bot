using Hackathon.Domain.Models.Core;
using LinqKit;
using System.Linq.Expressions;

namespace Hackathon.Application.Params
{
    public class UserParams<T> : BaseParams<T>
    where T: User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public override Expression<Func<T, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<T>(true);

            if (!string.IsNullOrEmpty(Name))
                predicate = predicate.And(x => x.Name.Contains(Name));

            if (!string.IsNullOrEmpty(Username))
                predicate = predicate.And(x => x.Username.Contains(Username));

            if (!string.IsNullOrEmpty(Email))
                predicate = predicate.And(x => x.Email.Contains(Email));

            return predicate;
        }
    }
}
