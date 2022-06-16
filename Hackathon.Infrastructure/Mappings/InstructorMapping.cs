using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class InstructorMapping : UserMapping<Instructor>
    {
        public InstructorMapping() : base("tb_instructor")
        {
        }

        public override void Configure(EntityTypeBuilder<Instructor> builder)
        {
            base.Configure(builder);

            builder
                .HasMany(x => x.Classrooms)
                .WithOne(x => x.Instructor)
                .HasForeignKey(x => x.InstructorId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


            builder
                .HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.Navigation(x => x.Classrooms).AutoInclude();
        }
    }
}
