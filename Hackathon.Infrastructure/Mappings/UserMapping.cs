using Hackathon.Domain.Core;
using Hackathon.Domain.Models.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class UserMapping<T> : RegisterMapping<T> where T : User
    {
        private readonly string _tableName;
        public UserMapping(string tableName) : base("tb_user")
        {
            _tableName = tableName;
        }
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.Property(x => x.Username).HasColumnName("userName").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(200)").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Password).HasColumnName("password").IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(200);
            builder.Property(x => x.BirthDate).HasColumnName("birthDate").IsRequired();

            builder
                .HasOne(x => x.UserRole)
                .WithMany()
                .HasForeignKey(x => x.UserRoleId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
