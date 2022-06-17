using Hackathon.Domain.Interfaces;
using Hackathon.Infrastructure.Context;

namespace Hackathon.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext _context { get; set; }
        public UnitOfWork(ApplicationContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
