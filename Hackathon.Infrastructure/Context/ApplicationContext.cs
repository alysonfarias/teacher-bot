using Microsoft.EntityFrameworkCore;

namespace Hackathon.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        // Domain

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
