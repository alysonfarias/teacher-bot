using Hackathon.Domain.core;

namespace Hackathon.Domain.models
{
    public class Instrutor : Identidade
    {
        public IEnumerable<Atividade> Atividades { get; set; }
        //Especialidade: Enum<Disciplina>
    }
}