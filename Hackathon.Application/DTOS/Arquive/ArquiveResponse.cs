
using Hackathon.Application.DTOS.Common;
using Hackathon.Application.DTOS.Enumerations;

namespace Hackathon.Application.DTOS.Arquive
{
    public class ArquiveResponse : RegisterViewModel
    {
        public string DataBase64 { get; set; }
        public FileTypeResponse FileType { get; set; }
    }
}