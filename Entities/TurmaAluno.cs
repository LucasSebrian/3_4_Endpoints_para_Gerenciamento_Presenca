namespace GerenciamentoPresenca.Entities
{
    public class TurmaAluno : EntityBase
    {
        public required Guid TurmaId { get; set; }
        public required Guid AlunoId { get; set; }

        public virtual Turma? Turma { get; set; }
        public virtual Aluno? Aluno { get; set; }
    }
}