
using FluentValidation.AspNetCore;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Interfaces;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Application.Services;
using Hackathon.Application.Services.Login;
using Hackathon.Application.Validators;
using Hackathon.Domain;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Context;
using Hackathon.Infrastructure.Repositories;
using Hackathon.Infrastructure.UnitOfWork;


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
            services.AddScoped<IDeliveryActivityService, DeliveryActivityService>();
            services.AddScoped<IDeliveryActivityRepository, DeliveryActivityRepository>();
            services.AddScoped<ILoginService<Admin>, LoginService<Admin>>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IClassRoomRepository, ClassRoomRepository>();

            //auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassRoomParticipantsService, ClassRoomParticipantsService>();

            services.AddScoped<IUserService<Instructor, InstructorRequest, InstructorResponse>, InstructorService>();
            services.AddScoped<IUserService<Student, StudentRequest, StudentResponse>, StudentService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IClassRoomParticipantsRepository, ClassRoomParticipantsRepository>();

            services.AddScoped<IUserRepository<Student>, StudentRepository>();
            services.AddScoped<IUserRepository<Instructor>, InstructorRepository>();
            services.AddScoped<IUserRepository<Admin>, AdminRepository>();

            services.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = false;
                fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

    }
}
