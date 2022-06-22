using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces.Base;
using Hackathon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hackathon.Infrastructure.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Register
    {
       protected readonly ApplicationContext _context;
       private readonly DbSet<T> _set;
       private IQueryable<T> _preQuery;

       public BaseRepository(ApplicationContext context)
       {
           _context = context;
           _set = context.Set<T>();
           _preQuery = _set.AsQueryable();
       }

       public virtual void AddPreQuery(Func<IQueryable<T>, IQueryable<T>> query)
       {
           _preQuery = query.Invoke(_preQuery);
       }

       public async Task<T> RemoveAsync(int id)
       {
           var obj = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
           if (obj == null)
               throw new InvalidOperationException($"Id: {id} para remover {typeof(T).Name} é invalido");

           var result = _set.Remove(obj);
           return await Task.FromResult(result.Entity);
       }

       public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool asNoTracking = true)
       {
           return await GetQueryable(filter, asNoTracking).ToListAsync();
       }

       public async Task<T> GetByIdAsync(int id)
       {
           return await Query().FirstOrDefaultAsync(x => x.Id == id);
       }

       public virtual IQueryable<T> Query()
       {
           return _preQuery;
       }

       public virtual async Task<T> RegisterAsync(T model)
       {
           model.CreatedAt = DateTime.Now;
           model.UpdatedAt = DateTime.Now;
           var result = _set.Add(model);
           return await Task.FromResult(result.Entity);
       }

       public virtual async Task<T> UpdateAsync(T model)
       {
           model.UpdatedAt = DateTime.Now;
           var result = _set.Update(model);
           return await Task.FromResult(result.Entity);
       }
       protected virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null,
           bool asNoTracking = true)
       {
           IQueryable<T> query = Query();
           if (filter is not null && filter.Parameters[0].Name != "f")
               query = query.Where(filter);

           if (asNoTracking)
               query = query.AsNoTracking();

           return query;
       }
    }
}