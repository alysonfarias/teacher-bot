using Hackathon.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Base
{
    public abstract class BaseUserMap<UserEntity> : BaseRegisterMap<UserEntity>
    where UserEntity: User
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<UserEntity> builder)
        
        {
            builder.Property(us => us.Name).IsRequired().HasMaxLength(200);
            builder.Property(us => us.Username).IsRequired().HasMaxLength(200);
            builder.Property(us => us.Email).IsRequired().HasMaxLength(200);              
            builder.Property(us => us.Password).IsRequired().HasMaxLength(200);
            //builder.Property(us => us.BirthDate).HasColumnType("datetime2"); 

            builder
                .HasOne(us => us.UserRole)
                .WithMany()
                .HasForeignKey(us => us.UserRoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);             
              
            ConfigureOtherUserProperties(builder);  
        }
    
        protected abstract void ConfigureOtherUserProperties(EntityTypeBuilder<UserEntity> builder);

    }
}