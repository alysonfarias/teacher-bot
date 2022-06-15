using Hackathon.Domain.core;

namespace Hackathon.Domain.models
{
    public class Aluno : Identidade
    {
        public decimal MediaGlobal { get; set; }
        public bool IsInfantil { get; set; }
        public IEnumerable<Atividade> Atividades { get; set; }
    }
}