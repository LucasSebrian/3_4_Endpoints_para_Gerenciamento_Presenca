namespace GerenciamentoPresenca.Entities
{
    public class Curso : EntityBase
    {
        public required string Nome { get; set; }
        public required string Sigla { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; } = default!;
    }
}