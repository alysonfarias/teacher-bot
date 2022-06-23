using Hackathon.Domain.Core.Common;
using System.Linq.Expressions;

namespace Hackathon.Domain.Interfaces.Base
{
    public interface IBaseRepository<T> where T : Register
    {
        IQueryable<T> Query();
        void AddPreQuery(Func<IQueryable<T>, IQueryable<T>> query);
        Task<T> RegisterAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> GetByIdAsync(int id);
    }
}
