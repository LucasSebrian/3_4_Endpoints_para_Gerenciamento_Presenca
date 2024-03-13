namespace GerenciamentoPresenca.Entities
{
    public enum TipoPresenca 
    {
        Pendente,
        Presencial,
        Online
    }

    public enum ChamadaStatus 
    {
        Pendente,
        Presente,
        Ausente,
        Justificado
    }
    
    public class Chamada : EntityBase
    {
        public required Guid AulaId { get; set; }
        public required Guid AlunoId { get; set; }
        public required Guid ProfessorId { get; set; }
        public required Guid PeriodoId { get; set; }
        public required ChamadaStatus Status { get; set; }

        public TipoPresenca TipoPresenca { get; set; }

        public virtual Aula Aula { get; set; } = default!;
        public virtual Aluno Aluno { get; set; } = default!;
        public virtual Professor Professor { get; set; } = default!;
        public virtual Periodo Periodo { get; set; } = default!;
    }
}