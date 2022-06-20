
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Hackathon.Infrastructure.Context;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Services.Login;
using Hackathon.Infrastructure.UnitOfWork;

namespace Hackathon.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<ApplicationContext>();

            //services
            services.AddScoped<ILoginService<Student>, LoginService<Student>();
            services.AddScoped<ILoginService<Instructor>, LoginService<Instructor>();

            //auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();


            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<IInstructorRepository,InstructorRepository>();

            services.AddScoped<IUserRepository<Student>,StudentRepository>();
            services.AddScoped<IUserRepository<Instructor>,InstructorRepository>();

            services.AddFluentValidation(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            return services;
        }
    
    }
}
