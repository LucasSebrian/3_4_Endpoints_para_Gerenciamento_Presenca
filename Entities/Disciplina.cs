namespace GerenciamentoPresenca.Entities
{
    public class Disciplina : EntityBase
    {
        public required string Nome { get; set; }
        public required Guid CursoId { get; set; }
        public required Guid ProfessorId { get; set; }
        
        public virtual Curso Curso { get; set; } = default!;
        public virtual Professor Professor { get; set; } = default!;

        public virtual ICollection<ConteudoProgramatico> ConteudosProgramaticos { get; set; } = default!;
        public virtual ICollection<Aula> Aulas { get; set; } = default!;
    }
}