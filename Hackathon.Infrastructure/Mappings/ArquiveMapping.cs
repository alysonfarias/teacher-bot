using Hackathon.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ArquiveMapping : RegisterMapping<Arquive>
    {
        public ArquiveMapping() : base("tb_arquive")
        {
        }

        public override void Configure(EntityTypeBuilder<Arquive> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.ClassRoom)
                .WithMany()
                .HasForeignKey(x => x.ClassRoomId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.FileType)
                .WithMany()
                .HasForeignKey(x => x.FileTypeId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Activity)
                .WithMany()
                .HasForeignKey(x => x.ActivityId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder
                .Property(x => x.DataBase64).HasColumnName("dataBase64").IsRequired();
        }
    }
}
