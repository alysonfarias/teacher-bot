using Hackathon.Domain.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
                .HasDefaultValueSql("getDate()");

            builder.Property(re => re.UpdatedAt)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("getDate()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            
            ConfigureOtherProperties(builder);
        }

        protected abstract void ConfigureOtherProperties(EntityTypeBuilder<RegisterEntity> builder);
        
    }
}