using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Domain.Models
{
    public class Arquive : Register
    {
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }
        public FileType FileType { get; set; }
        public int FileTypeId { get; set; }
        public string DataBase64 { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }
    }
}
