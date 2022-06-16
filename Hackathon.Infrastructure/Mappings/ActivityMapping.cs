using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ActivityMapping : RegisterMapping<Activity>
    {
        public ActivityMapping() : base("tb_activity")
        {
        }

        public override void Configure(EntityTypeBuilder<Activity> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title).HasColumnName("name").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.DueDate).HasColumnName("dueDate").IsRequired();

            builder
                .HasOne(x => x.ClassRoom)
                .WithMany()
                .HasForeignKey(x => x.ClassRoomId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Arquives)
                .WithOne(x => x.Activity)
                .HasForeignKey(x => x.ActivityId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);    
        }
    }
}
