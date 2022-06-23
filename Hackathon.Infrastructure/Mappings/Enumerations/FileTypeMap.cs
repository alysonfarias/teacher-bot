using Hackathon.Domain.Models.Enumerations;
using Hackathon.Infrastructure.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Infrastructure.Mappings.Enumerations
{
    public class FileTypeMap : BaseEnumerationMap<FileType>
    {
        protected override void ConfigureOtherProperties(EntityTypeBuilder<FileType> builder)
        {
            builder.ToTable("tb_File_Types");
        }
    }
}