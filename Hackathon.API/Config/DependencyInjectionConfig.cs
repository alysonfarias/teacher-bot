
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Repositories;

namespace Hackathon.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<IInstructorRepository,InstructorRepository>();
            services.AddScoped<IUserRepository<Student>,StudentRepository>();
            services.AddScoped<IUserRepository<Instructor>,InstructorRepository>();

            return services;
        }
    
    }
}