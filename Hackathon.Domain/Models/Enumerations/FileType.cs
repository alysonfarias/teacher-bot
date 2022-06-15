using Hackathon.Domain.Core;

namespace Hackathon.Domain.Models.Enumerations
{
    public class FileType : Enumeration
    {
        public static FileType PDF = new(1, nameof(PDF));
        public static FileType PNG = new(2, nameof(PNG));
        public static FileType JPEG = new(3, nameof(JPEG));
        public static FileType JPG = new(4, nameof(JPG));
        public static FileType MP3 = new(5, nameof(MP3));

        public FileType()
        { }
        public FileType(int id, string name) : base(id, name)
        { }
    }
}
