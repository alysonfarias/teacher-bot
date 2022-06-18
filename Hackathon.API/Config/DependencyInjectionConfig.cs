using Hackathon.Application.Interfaces;
using Hackathon.Application.Services;
using Hackathon.Application.Services.Login;
using Hackathon.Domain.Interfaces;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories;
using Hackathon.Infrastructure.UnitOfWork;

namespace Hackathon.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection SolveDependencyInjection (this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            //services
            services.AddScoped<ILoginService, LoginService>();

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();


            //auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
