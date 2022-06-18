using Hackathon.Domain.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Base
{
    public abstract class BaseRegisterMap<RegisterEntity> : IEntityTypeConfiguration<RegisterEntity>
    where RegisterEntity : Register
    {
        public void Configure(EntityTypeBuilder<RegisterEntity> builder)
        {
            builder.HasKey(re => re.Id);

            builder.Property(re => re.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(re => re.UpdatedAt)
                .HasColumnType("datetime");
            
            ConfigureOtherProperties(builder);
        }

        protected abstract void ConfigureOtherProperties(EntityTypeBuilder<RegisterEntity> builder);
        
    }
}