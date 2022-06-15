namespace Hackathon.Domain.models
{
    public class AlunoAtividades
    {
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Atividade Atividade { get; set; }
        public int AtividadeId { get; set; }
    }
}