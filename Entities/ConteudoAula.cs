namespace GerenciamentoPresenca.Entities
{
    public class ConteudoAula : EntityBase
    {
        public required Guid ConteudoProgramaticoId { get; set; }
        public required Guid AulaId { get; set; }
        public required string InformacoesComplementares { get; set; }

        public virtual ConteudoProgramatico ConteudoProgramatico { get; set; } = default!;
        public virtual Aula Aula { get; set; } = default!;
    }
}