namespace GerenciamentoPresenca.Entities
{
    public class ConteudoProgramatico : EntityBase
    {
        public required string Nome { get; set; }
        public required Guid DisciplinaId { get; set; }
        public required int Codigo { get; set; }
        public required string Descricao { get; set; }

        public virtual Disciplina Disciplina { get; set; } = default!;
        public virtual ICollection<ConteudoAula> Aulas { get; set; } = default!;
    }
}