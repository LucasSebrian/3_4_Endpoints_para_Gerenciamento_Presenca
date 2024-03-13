namespace GerenciamentoPresenca.Entities
{
    public class Aluno : EntityBase
    {
        public required string Nome { get; set; }
        public required string RM { get; set; }

        public virtual ICollection<TurmaAluno> Turmas { get; set; } = default!;
        public virtual ICollection<Chamada> Chamadas { get; set; } = default!;
    }
}