using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ClassRoomMap : BaseRegisterMap<ClassRoom>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<ClassRoom> builder)
        {
            builder.Property(cl=>cl.Name).IsRequired().HasMaxLength(200);
            builder.Property(cl=>cl.Description).IsRequired().HasMaxLength(500);

            builder
                .HasMany(cl => cl.Activities)
                .WithOne()
                .HasForeignKey(at => at.ClassRoomId )
                .IsRequired();
            
                
        }
    }
}