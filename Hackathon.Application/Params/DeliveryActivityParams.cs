using System.Linq.Expressions;
using Hackathon.Domain.Models;
using LinqKit;

namespace Hackathon.Application.Params
{
    public class DeliveryActivityParams : BaseParams<DeliveryActivity>
    {
        public int? ActivityId { get; set; }
        public override Expression<Func<DeliveryActivity, bool>> Filter()
        {
            var predicate = PredicateBuilder.New<DeliveryActivity>(true);

            if (ActivityId != 0)
                predicate = predicate.And(x => x.ActivityId == ActivityId);

            return predicate;
        }
        
    }
}