using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Enumerations
{
    public class UserRoleMap : BaseEnumerationMap<UserRole>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("tb_User_Roles");
        }
    }
}