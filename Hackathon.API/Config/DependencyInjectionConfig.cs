
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
using Hackathon.Domain;
using Hackathon.Application.Services;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.DTOS.Instructor;

namespace Hackathon.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<ApplicationContext>();

            //services
            services.AddScoped<ILoginService<Student>, LoginService<Student>>();
            services.AddScoped<ILoginService<Instructor>, LoginService<Instructor>>();
            services.AddScoped<ILoginService<Admin>, LoginService<Admin>>();

            //auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IUserService<Instructor, InstructorRequest, InstructorResponse>, InstructorService>();
            services.AddScoped<IUserService<Student, StudentRequest, StudentResponse>, StudentService>();

            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<IInstructorRepository,InstructorRepository>();

            services.AddScoped<IUserRepository<Student>,StudentRepository>();
            services.AddScoped<IUserRepository<Instructor>,InstructorRepository>();
            services.AddScoped<IUserRepository<Admin>,AdminRepository>();

            services.AddFluentValidation(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    
    }
}
