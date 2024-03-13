namespace GerenciamentoPresenca.Entities
{
    public class Turma : EntityBase
    {
        public required string Code { get; set; }
        public required string Nome { get; set; }
        public required Guid CursoId { get; set; }

        public virtual Curso Curso { get; set; } = default!;
        public virtual ICollection<TurmaAluno> Alunos { get; set; } = default!;
        public virtual ICollection<Aula> Aulas { get; set; } = default!;
    }
}