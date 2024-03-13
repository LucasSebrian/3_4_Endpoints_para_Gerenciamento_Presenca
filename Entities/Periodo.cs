namespace GerenciamentoPresenca.Entities
{
    public enum Status 
    {
        Pendente,
        Andamento,
        Finalizado
    }

    public class Periodo : EntityBase
    {
        public required int Numero { get; set; }
        public required TimeOnly HoraInicio { get; set; }
        public required TimeOnly HoraFim { get; set; }
        public required Status Status { get; set; }
        public required Guid AulaId { get; set; }

        public virtual Aula Aula { get; set; } = default!;
        public virtual ICollection<Chamada> Chamadas { get; set; } = default!;
    }
}