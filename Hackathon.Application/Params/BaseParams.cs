using Hackathon.Domain.Core.Common;
using System.Linq.Expressions;

namespace Hackathon.Application.Params
{
    public abstract class BaseParams<T> where T : Register
    {
        public abstract Expression<Func<T, bool>> Filter();
        protected BaseParams() { }
    }
}
