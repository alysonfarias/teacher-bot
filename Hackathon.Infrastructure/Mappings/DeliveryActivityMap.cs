using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class DeliveryActivityMap : BaseRegisterMap<DeliveryActivity>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<DeliveryActivity> builder)
        {
            builder
                .HasOne(da => da.Student)
                .WithMany()
                .HasForeignKey(da => da.StudentId)
                .IsRequired();
            builder
                .HasOne(da => da.Activity)
                .WithMany()
                .HasForeignKey(da => da.ActivityId)
                .IsRequired();
        }
    }
}