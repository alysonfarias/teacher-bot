using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class StudentMapping : UserMapping<Student>
    {
        public StudentMapping() : base("tb_student")
        {
        }

        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.ClassRooms)
                .WithMany(x => x.Students)
                .UsingEntity<StudentClassRoom>(
                    x => x.HasOne(p => p.ClassRoom).WithMany().HasForeignKey(x => x.ClassRoomId),
                    x => x.HasOne(p => p.Student).WithMany().HasForeignKey(x => x.StudentId),
                    x =>
                    {
                        x.ToTable("tb_student_classroom");

                        x.HasKey(p => new { p.ClassRoomId, p.StudentId });

                        x.Property(p => p.ClassRoomId).HasColumnName("id_classroom").IsRequired();
                        x.Property(p => p.StudentId).HasColumnName("id_student").IsRequired();
                    }
                ); ;
            //falta implementar a config de responsible phones
        }
    }
}
