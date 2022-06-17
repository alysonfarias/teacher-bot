using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ClassRoomMapping : RegisterMapping<ClassRoom>
    {
        public ClassRoomMapping() : base("tb_classroom")
        {
        }

        public override void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);

            builder
                .HasOne(x => x.Instructor)
                .WithMany()
                .HasForeignKey(x => x.InstructorId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Activities)
                .WithOne(x => x.ClassRoom)
                .HasForeignKey(x => x.ClassRoomId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
