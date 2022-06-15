using Hackathon.Domain.core;

namespace Hackathon.Domain.models.enums
{
    public class Disciplina : Enumeration
    {
        public static Disciplina Portugues = new Disciplina(1, nameof(Portugues));
        public static Disciplina Matematica = new Disciplina(1, nameof(Matematica));
        public static Disciplina Ingles = new Disciplina(1, nameof(Ingles));
        public static Disciplina Programacao = new Disciplina(1, nameof(Programacao));

        public Disciplina(int id, string name) : base(id, name)
        { }
    }
}