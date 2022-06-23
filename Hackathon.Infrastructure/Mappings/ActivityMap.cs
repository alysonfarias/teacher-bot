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
                .WithOne(at => at.Activity)
                .HasForeignKey(aq=>aq.ActivityId)
                .IsRequired();

            builder
                .HasMany(at => at.StudentPerformers)
                .WithMany(at => at.ActivitiesDone)
                .UsingEntity<DeliveryActivity>(
                    x => x.HasOne(p => p.Student).WithMany().HasForeignKey(p => p.StudentId),
                    x => x.HasOne(p => p.Activity).WithMany().HasForeignKey(p => p.ActivityId),
                    x =>
                    {
                        x.ToTable("Tb_DeliveryActive");
                        x.HasKey(p => new { p.ActivityId, p.StudentId });
                    });

        }
    }
}