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

            //Create the Admin
            
        }
    }
}
