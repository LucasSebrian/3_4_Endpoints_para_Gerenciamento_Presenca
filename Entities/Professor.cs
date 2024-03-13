namespace GerenciamentoPresenca.Entities
{
    public class Professor : EntityBase
    {
        public required string Nome { get; set; }
        public required string RM { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; } = default!;
        public virtual ICollection<Chamada> Chamadas { get; set; } = default!;
    }
}