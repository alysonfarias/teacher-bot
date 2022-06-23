using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class StudentMap : BaseUserMap<Student>
    {
        protected override void ConfigureOtherUserProperties(EntityTypeBuilder<Student> builder)
        {
            builder.Property(st => st.ResponsiblePhone).HasMaxLength(20);

            builder.HasMany(x => x.ClassRooms)
            .WithMany(x => x.Students)
            .UsingEntity<ClassRoomParticipants>(
                x => x.HasOne(p => p.ClassRoom).WithMany().HasForeignKey(x => x.ClassRoomId),
                x => x.HasOne(p => p.Student).WithMany().HasForeignKey(x => x.StudentId),
                x =>
                {
                    x.ToTable("tb_student_classroom");
                    x.HasKey(p => new { p.ClassRoomId, p.StudentId });
                });
        }
    }
}