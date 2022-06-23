using Hackathon.Domain.Core.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Base
{
    public abstract class BaseEnumerationMap<EnumerationEntity> : IEntityTypeConfiguration<EnumerationEntity>
    where EnumerationEntity : Enumeration
    {
        public void Configure(EntityTypeBuilder<EnumerationEntity> builder)
        {
            builder.HasKey(en => en.Id);
            builder.Property(en=> en.Name).HasColumnType("Varchar(30)").IsRequired();
            ConfigureOtherProperties(builder);
        }

        protected abstract void ConfigureOtherProperties(EntityTypeBuilder<EnumerationEntity> builder);
                
    }
}