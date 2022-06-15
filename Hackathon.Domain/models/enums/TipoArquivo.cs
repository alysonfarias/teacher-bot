using Hackathon.Domain.core;

namespace Hackathon.Domain.models.enums
{
    public class TipoArquivo : Enumeration
    {
        public static TipoArquivo PDF = new TipoArquivo(1, nameof(PDF));
        public static TipoArquivo PNG = new TipoArquivo(1, nameof(PNG));
        public static TipoArquivo JPG = new TipoArquivo(1, nameof(JPG));
        public static TipoArquivo MP4 = new TipoArquivo(1, nameof(MP4));

        public TipoArquivo(int id, string name) : base(id, name)
        { }
    }
}