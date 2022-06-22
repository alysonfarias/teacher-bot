using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ActivityMap : BaseRegisterMap<Activity>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(at=>at.Title).IsRequired().HasMaxLength(200);
            builder.Property(at=>at.Description).IsRequired().HasMaxLength(500);
            builder.Property(at=>at.DueDate).IsRequired().HasMaxLength(500);
            
            builder
                .HasMany(at=>at.Arquives)
                .WithOne()
                .HasForeignKey(aq=>aq.ActivityId)
                .IsRequired();
            
            builder
                .HasMany(at => at.StudentPerformers)
                .WithMany(st => st.ActivitiesDone)
                .UsingEntity<StudentActivity>(
                    x => x.HasOne(sa => sa.Student).WithMany().HasForeignKey(sa => sa.StudentId),
                    x => x.HasOne(sa => sa.Activity).WithMany().HasForeignKey(sa => sa.ActivityId),
                    x => 
                    {
                        x.ToTable("tb_student_activity");
                        x.HasKey(sa => new { sa.StudentId, sa.ActivityId });
                    });
        }
    }
}