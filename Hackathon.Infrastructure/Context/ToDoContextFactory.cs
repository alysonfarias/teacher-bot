using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hackathon.Infrastructure.Context
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            // builder.UseSqlServer(configuration.GetConnectionString("AWS_SQLServerConnection"));
            return new ApplicationContext(builder.Options);
        }
    }
}
