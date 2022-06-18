using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Domain.Models
{
    public class Arquive : Register
    {
        public string DataBase64 { get; set; }
        public int FileTypeId { get; set; }
        public FileType FileType { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
