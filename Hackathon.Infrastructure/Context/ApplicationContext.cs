using Hackathon.Domain;
using Hackathon.Domain.Core;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Mappings;
using Hackathon.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Hackathon.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Arquive> Arquives { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder
                .Entity<FileType>()
                .HasData(Enumeration.GetAll<FileType>());

            modelBuilder
                .Entity<Subject>()
                .HasData(Enumeration.GetAll<Subject>());

            modelBuilder
                .Entity<UserRole>()
                .HasData(Enumeration.GetAll<UserRole>());

            //TODO: Create the Admin
            modelBuilder
            .Entity<Admin>()
            .HasData(new Admin
            {
                Id = 1,
                Username = "admin",
                Password = PasswordHasher.Hash("123@adm"),
                Email = "admin@api.com",
                Name = "Admin Root Application",
                CreatedAt = DateTime.ParseExact("27/05/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                UserRoleId = UserRole.Admin.Id
            });

            modelBuilder
            .Entity<Instructor>()
            .HasData(new Instructor
            {
                Id = 1,
                Username = "instru",
                SubjectId = 1,
                Password = PasswordHasher.Hash("123@instru"),
                Email = "instru@api.com",
                Name = "kleber",
                CreatedAt = DateTime.ParseExact("27/05/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                UserRoleId = UserRole.Instructor.Id,
                BirthDate = DateTime.ParseExact("12/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture)

            });

            modelBuilder
            .Entity<Student>()
            .HasData(new Student
            {
                Id = 1,
                Username = "instru",
                Password = PasswordHasher.Hash("123@instru"),
                Email = "instru@api.com",
                Name = "kleber",
                CreatedAt = DateTime.ParseExact("27/05/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                UserRoleId = UserRole.Student.Id,
                BirthDate = DateTime.ParseExact("12/05/2001", "dd/MM/yyyy", CultureInfo.InvariantCulture),
            });

        }
    }
}
