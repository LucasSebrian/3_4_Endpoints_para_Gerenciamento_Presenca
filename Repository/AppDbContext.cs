using GerenciamentoPresenca.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPresenca.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; } = default!;
        public DbSet<Aula> Aulas { get; set; } = default!;
        public DbSet<Chamada> Chamadas { get; set; } = default!;
        public DbSet<ConteudoAula> ConteudoAulas { get; set; } = default!;
        public DbSet<ConteudoProgramatico> ConteudoProgramaticos { get; set; } = default!;
        public DbSet<Curso> Cursos { get; set; } = default!;
        public DbSet<Disciplina> Disciplinas { get; set; } = default!;
        public DbSet<Periodo> Periodos { get; set; } = default!;
        public DbSet<Professor> Professores { get; set; } = default!;
        public DbSet<Turma> Turmas { get; set; } = default!;
        public DbSet<TurmaAluno> TurmaAlunos { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the foreign key relationship with desired action
            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Turma)
                .WithMany(t => t.Aulas)
                .HasForeignKey(a => a.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConteudoAula>()
                .HasOne(ca => ca.ConteudoProgramatico)
                .WithMany(cp => cp.Aulas)
                .HasForeignKey(ca => ca.ConteudoProgramaticoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chamada>()
                .HasOne(c => c.Periodo)
                .WithMany(p => p.Chamadas)
                .HasForeignKey(c => c.PeriodoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Chamada>()
                .HasOne(c => c.Professor)
                .WithMany(a => a.Chamadas)
                .HasForeignKey(c => c.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            ConfigureDefaultSeedValues(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureDefaultSeedValues(ModelBuilder modelBuilder)
        {
            Aluno felipe = new() { Nome = "Felipe", RM = "RM347765" };
            Aluno vinicius = new() { Nome = "Vinicius", RM = "RM347982" };
            Aluno lucas = new() { Nome = "Lucas", RM = "RM348290" };
            Aluno leonardo = new() { Nome = "Leonardo", RM = "RM347972" };

            Professor professor = new() { Nome = "Ricardo", RM = "PF1931" };

            Curso curso = new() { Sigla = "ARCHNET", Nome = "ARQUITETURA E DESENVOLVIMENTO .NET" };

            Turma turma = new()
            {
                CursoId = curso.Id,
                Nome = "Turma 2NETR",
                Code = "2NETR",
                Alunos = []
            };

            TurmaAluno turmaAluno = new() { AlunoId = felipe.Id, TurmaId = turma.Id };
            TurmaAluno turmaAluno2 = new() { AlunoId = vinicius.Id, TurmaId = turma.Id };
            TurmaAluno turmaAluno3 = new() { AlunoId = lucas.Id, TurmaId = turma.Id };
            TurmaAluno turmaAluno4 = new() { AlunoId = leonardo.Id, TurmaId = turma.Id };

            Disciplina disciplina = new() { CursoId = curso.Id, ProfessorId = professor.Id, Nome = "Arquitetura de Banco de Dados e Persistência" };

            ConteudoProgramatico conteudoProgramatico = new() { DisciplinaId = disciplina.Id, Codigo = 1, Nome = "Introdução a banco de dados", Descricao = "Conceitos iniciais de banco de dados" };
            ConteudoProgramatico conteudoProgramatico2 = new() { DisciplinaId = disciplina.Id, Codigo = 2, Nome = "Modelagem de dados", Descricao = "Modelagem de dados com MER" };
            ConteudoProgramatico conteudoProgramatico3 = new() { DisciplinaId = disciplina.Id, Codigo = 3, Nome = "SQL", Descricao = "Linguagem SQL" };

            Aula aula = new() { TurmaId = turma.Id, Data = new DateOnly(2024, 2, 1), DisciplinaId = disciplina.Id, Status = StatusAula.Pendente };

            ConteudoAula conteudoAula = new() { ConteudoProgramaticoId = conteudoProgramatico.Id, AulaId = aula.Id, InformacoesComplementares = "" };

            Periodo periodo = new() { AulaId = aula.Id, Numero = 1, Status = Status.Pendente, HoraInicio = new TimeOnly(19, 0), HoraFim = new TimeOnly(21, 0) };
            Periodo periodo2 = new() { AulaId = aula.Id, Numero = 2, Status = Status.Pendente, HoraInicio = new TimeOnly(21, 20), HoraFim = new TimeOnly(22, 45) };

            Chamada chamada = new() { PeriodoId = periodo.Id, ProfessorId = professor.Id, AlunoId = felipe.Id, AulaId = aula.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada2 = new() { PeriodoId = periodo.Id, ProfessorId = professor.Id, AlunoId = vinicius.Id, AulaId = aula.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada3 = new() { PeriodoId = periodo.Id, ProfessorId = professor.Id, AlunoId = lucas.Id, AulaId = aula.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada4 = new() { PeriodoId = periodo.Id, ProfessorId = professor.Id, AlunoId = leonardo.Id, AulaId = aula.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };

            Aula aula2 = new() { TurmaId = turma.Id, Data = new DateOnly(2024, 2, 8), DisciplinaId = disciplina.Id, Status = StatusAula.Pendente };

            ConteudoAula conteudoAula2 = new() { ConteudoProgramaticoId = conteudoProgramatico2.Id, AulaId = aula2.Id, InformacoesComplementares = "" };

            Periodo periodo3 = new() { AulaId = aula2.Id, Numero = 1, Status = Status.Pendente, HoraInicio = new TimeOnly(19, 0), HoraFim = new TimeOnly(21, 0) };
            Periodo periodo4 = new() { AulaId = aula2.Id, Numero = 2, Status = Status.Pendente, HoraInicio = new TimeOnly(21, 20), HoraFim = new TimeOnly(22, 45) };

            Chamada chamada5 = new() { PeriodoId = periodo3.Id, ProfessorId = professor.Id, AlunoId = felipe.Id, AulaId = aula2.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada6 = new() { PeriodoId = periodo3.Id, ProfessorId = professor.Id, AlunoId = vinicius.Id, AulaId = aula2.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada7 = new() { PeriodoId = periodo3.Id, ProfessorId = professor.Id, AlunoId = lucas.Id, AulaId = aula2.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada8 = new() { PeriodoId = periodo3.Id, ProfessorId = professor.Id, AlunoId = leonardo.Id, AulaId = aula2.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };

            Aula aula3 = new() { TurmaId = turma.Id, Data = new DateOnly(2024, 2, 15), DisciplinaId = disciplina.Id, Status = StatusAula.Pendente };

            ConteudoAula conteudoAula3 = new() { ConteudoProgramaticoId = conteudoProgramatico3.Id, AulaId = aula3.Id, InformacoesComplementares = "" };

            Periodo periodo5 = new() { AulaId = aula3.Id, Numero = 1, Status = Status.Pendente, HoraInicio = new TimeOnly(19, 0), HoraFim = new TimeOnly(21, 0) };
            Periodo periodo6 = new() { AulaId = aula3.Id, Numero = 2, Status = Status.Pendente, HoraInicio = new TimeOnly(21, 20), HoraFim = new TimeOnly(22, 45) };

            Chamada chamada9 = new() { PeriodoId = periodo5.Id, ProfessorId = professor.Id, AlunoId = felipe.Id, AulaId = aula3.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada10 = new() { PeriodoId = periodo5.Id, ProfessorId = professor.Id, AlunoId = vinicius.Id, AulaId = aula3.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada11 = new() { PeriodoId = periodo5.Id, ProfessorId = professor.Id, AlunoId = lucas.Id, AulaId = aula3.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };
            Chamada chamada12 = new() { PeriodoId = periodo5.Id, ProfessorId = professor.Id, AlunoId = leonardo.Id, AulaId = aula3.Id, Status = ChamadaStatus.Pendente, TipoPresenca = TipoPresenca.Pendente };

            modelBuilder.Entity<Aluno>().HasData(felipe, vinicius, lucas, leonardo);
            modelBuilder.Entity<Professor>().HasData(professor);
            modelBuilder.Entity<Curso>().HasData(curso);
            modelBuilder.Entity<Turma>().HasData(turma);
            modelBuilder.Entity<TurmaAluno>().HasData(turmaAluno, turmaAluno2, turmaAluno3, turmaAluno4);
            modelBuilder.Entity<Disciplina>().HasData(disciplina);
            modelBuilder.Entity<ConteudoProgramatico>().HasData(conteudoProgramatico, conteudoProgramatico2, conteudoProgramatico3);
            modelBuilder.Entity<Aula>().HasData(aula, aula2, aula3);
            modelBuilder.Entity<ConteudoAula>().HasData(conteudoAula, conteudoAula2, conteudoAula3);
            modelBuilder.Entity<Periodo>().HasData(periodo, periodo2, periodo3, periodo4, periodo5, periodo6);
            modelBuilder.Entity<Chamada>().HasData(chamada, chamada2, chamada3, chamada4, chamada5, chamada6, chamada7, chamada8, chamada9, chamada10, chamada11, chamada12);
        }
    }
}