using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class StudentMap : BaseUserMap<Student>
    {
        protected override void ConfigureOtherUserProperties(EntityTypeBuilder<Student> builder)
        {
            /*
                Configurar o ResponsiblePhones , ao se tratar de um atributo multi valorado
                eh criada uma nova tabela com o StudentId e o Telefone
            */
            builder
                .HasOne(st=> st.UserRole)
                .WithMany()
                .HasForeignKey(st=>st.UserRoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        
            builder
                .HasMany(st => st.ClassRooms)
                .WithMany(cl => cl.Students);
        }
    }
}