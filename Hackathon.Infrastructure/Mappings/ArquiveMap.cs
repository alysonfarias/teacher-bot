using Hackathon.Domain.Models;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings
{
    public class ArquiveMap : BaseRegisterMap<Arquive>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Arquive> builder)
        {
            builder.Property(aq=>aq.DataBase64);

        }
    }
}