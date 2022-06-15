using Hackathon.Domain.models.enums;

namespace Hackathon.Domain.models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public TipoArquivo TipoArquivo { get; set; }
        public int TipoArquivoId { get; set; }
        public DateTime DataPostagem { get; set; }
        public DateTime DataEntrega { get; set; }
        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
        public Instrutor Instrutor { get; set; }
        public int InstrutorId { get; set; }
        public IEnumerable<Aluno> Alunos { get; set; }
    }
}