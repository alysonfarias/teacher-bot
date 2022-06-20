using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Enumerations
{
    public class SubjectMap : BaseEnumerationMap<Subject>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("tb_Subjects");
        }
    }
}