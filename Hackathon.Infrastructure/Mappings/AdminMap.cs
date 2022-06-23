using Hackathon.Domain;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class AdminMap : BaseUserMap<Admin>
    {
        protected override void ConfigureOtherUserProperties(EntityTypeBuilder<Admin> builder)
        {
            //throw new NotImplementedException();
        }
    }
}
