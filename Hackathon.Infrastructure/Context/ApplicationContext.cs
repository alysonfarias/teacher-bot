using Hackathon.Domain.Core;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Hackathon.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
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

            modelBuilder.ApplyConfiguration(new EnumerationMapping<FileType>());
            modelBuilder.ApplyConfiguration(new EnumerationMapping<Subject>());
            modelBuilder.ApplyConfiguration(new EnumerationMapping<UserRole>());

            modelBuilder
                .Entity<FileType>()
                .HasData(Enumeration.GetAll<FileType>());

            modelBuilder
                .Entity<Subject>()
                .HasData(Enumeration.GetAll<Subject>());

            modelBuilder
                .Entity<UserRole>()
                .HasData(Enumeration.GetAll<UserRole>());

            modelBuilder
                .Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "admin",
                    //Password = PasswordHasher.Hash("Pass123$"),
                    Password = "Pass123$",
                    Email = "admin@api.com",
                    Name = "Admin Root Application",
                    CreatedAt = DateTime.ParseExact("15/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    BirthDate = DateTime.ParseExact("15/06/2022", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    UserRoleId = UserRole.Admin.Id
                });
        }
    }
}
