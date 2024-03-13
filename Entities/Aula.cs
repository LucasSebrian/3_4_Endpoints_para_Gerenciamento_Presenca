namespace GerenciamentoPresenca.Entities
{
    public enum StatusAula
    {
        Pendente,
        Realizada
    }

    public class Aula : EntityBase 
    {
        public required Guid TurmaId { get; set; }
        public required Guid DisciplinaId { get; set; }
        public required DateOnly Data { get; set; }

        public StatusAula Status { get; set; }

        public virtual Disciplina Disciplina { get; set; } = default!;
        public virtual Turma Turma { get; set; } = default!;

        public virtual ICollection<ConteudoAula> Conteudos { get; set; } = default!;
        public virtual ICollection<Chamada> Chamadas { get; set; } = default!;
    }
}