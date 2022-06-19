using Hackathon.Domain.Interfaces;
using Hackathon.Infrastructure.Repositories;

namespace Hackathon.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
    
    }
}