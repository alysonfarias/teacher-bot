using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class InstructorMap : BaseUserMap<Instructor>
    {
        protected override void ConfigureOtherUserProperties(EntityTypeBuilder<Instructor> builder)
        {
            builder
                .HasOne(it => it.Subject)
                .WithMany()
                .HasForeignKey(it => it.SubjectId);

            builder
                .HasMany(it => it.Classrooms)
                .WithOne(it => it.Instructor)
                .HasForeignKey(cl => cl.InstructorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}