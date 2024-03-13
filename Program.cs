using GerenciamentoPresenca.Entities;
using GerenciamentoPresenca.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    // options.UseInMemoryDatabase("GerenciamentoPresenca");
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTION_STRING"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region "Endpoints Aluno"

app.MapGet("/service/alunos", (AppDbContext dbContext) =>
{
    return dbContext.Alunos.ToListAsync();
})
.WithName("GetAlunos")
.WithTags("Alunos")
.WithOpenApi();

app.MapPost("/service/alunos", (AppDbContext dbContext, Aluno aluno) =>
{
    dbContext.Alunos.Add(aluno);
    dbContext.SaveChanges();
    return Results.Created($"/service/alunos/{aluno.Id}", aluno);
})
.WithName("PostAlunos")
.WithTags("Alunos")
.WithOpenApi();

app.MapGet("/service/alunos/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Alunos.FindAsync(id);
})
.WithName("GetAluno")
.WithTags("Alunos")
.WithOpenApi();

app.MapPut("/service/alunos/{id}", (AppDbContext dbContext, Guid id, Aluno aluno) =>
{
    if (id != aluno.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(aluno).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutAluno")
.WithTags("Alunos")
.WithOpenApi();

app.MapDelete("/service/alunos/{id}", (AppDbContext dbContext, Guid id) =>
{
    var aluno = dbContext.Alunos.Find(id);
    if (aluno == null)
    {
        return Results.NotFound();
    }

    dbContext.Alunos.Remove(aluno);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteAluno")
.WithTags("Alunos")
.WithOpenApi();

#endregion

#region "Endpoints Aula"

app.MapGet("/service/aulas/pendentes/{data}/{professorId}", (DateOnly data, Guid professorId, AppDbContext dbContext) =>
{
    return (from aula in dbContext.Aulas
            join periodo in dbContext.Periodos on aula.Id equals periodo.AulaId
            join disciplina in dbContext.Disciplinas on aula.DisciplinaId equals disciplina.Id
            join curso in dbContext.Cursos on disciplina.CursoId equals curso.Id
            join turma in dbContext.Turmas on curso.Id equals turma.CursoId
            where
                aula.Data == data &&
                aula.Status == StatusAula.Pendente &&
                disciplina.ProfessorId == professorId
            select new
            {
                Periodo = new { periodo.Id, periodo.Numero },
                Turma = new { turma.Code },
                Disciplina = new { disciplina.Nome },
            }).ToListAsync();
})
.WithName("GetAulasPendentes")
.WithTags("Aulas")
.WithOpenApi();

app.MapGet("/service/aulas/realizadas/{data}/{professorId}", (DateOnly data, Guid professorId, AppDbContext dbContext) =>
{
    return (from aula in dbContext.Aulas
            join periodo in dbContext.Periodos on aula.Id equals periodo.AulaId
            join disciplina in dbContext.Disciplinas on aula.DisciplinaId equals disciplina.Id
            join curso in dbContext.Cursos on disciplina.CursoId equals curso.Id
            join turma in dbContext.Turmas on curso.Id equals turma.CursoId
            where
                aula.Data == data &&
                aula.Status == StatusAula.Realizada &&
                disciplina.ProfessorId == professorId
            select new
            {
                Turma = new { turma.Code },
                Disciplina = new { disciplina.Nome },
                Aula = new
                {
                    aula.Data,
                    DataFinalizado = aula.UpdatedAt
                },
                Periodo = new
                {
                    periodo.Numero,
                    periodo.Status
                }
            }).ToListAsync();
})
.WithName("GetAulasRealizadas")
.WithTags("Aulas")
.WithOpenApi();

app.MapGet("/service/aulas", (AppDbContext dbContext) =>
{
    return dbContext.Aulas.ToListAsync();
})
.WithName("GetAulas")
.WithTags("Aulas")
.WithOpenApi();

app.MapPost("/service/aulas", (AppDbContext dbContext, Aula aula) =>
{
    dbContext.Aulas.Add(aula);
    dbContext.SaveChanges();
    return Results.Created($"/service/aulas/{aula.Id}", aula);
})
.WithName("PostAulas")
.WithTags("Aulas")
.WithOpenApi();

app.MapGet("/service/aulas/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Aulas.FindAsync(id);
})
.WithName("GetAula")
.WithTags("Aulas")
.WithOpenApi();

app.MapPut("/service/aulas/{id}", (AppDbContext dbContext, Guid id, Aula aula) =>
{
    if (id != aula.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(aula).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutAula")
.WithTags("Aulas")
.WithOpenApi();

app.MapDelete("/service/aulas/{id}", (AppDbContext dbContext, Guid id) =>
{
    var aula = dbContext.Aulas.Find(id);
    if (aula == null)
    {
        return Results.NotFound();
    }

    dbContext.Aulas.Remove(aula);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteAula")
.WithTags("Aulas")
.WithOpenApi();

#endregion

#region "Endpoints Chamada"

app.MapGet("/service/chamadas/aula/{periodoId}", (Guid periodoId, AppDbContext dbContext) =>
{
    var periodo = dbContext.Periodos.Include(i => i.Aula).ThenInclude(i => i.Turma).ThenInclude(i => i.Alunos).FirstOrDefault(x => x.Id == periodoId) ?? throw new Exception("Período não encontrado");

    var chamadas = (from aluno in dbContext.Alunos
                    join chamada in dbContext.Chamadas on aluno.Id equals chamada.AlunoId
                    where chamada.PeriodoId == periodoId
                    select new
                    {
                        chamada.Id,
                        chamada.Status,
                        Tipo = chamada.TipoPresenca,
                        Aluno = new { aluno.RM, aluno.Nome }
                    }).ToList();

    var conteudoAulas =  dbContext.ConteudoAulas
    .Where(c => c.AulaId == periodo.AulaId)
    .Select(x => new {
        x.Id,
        x.ConteudoProgramatico.Codigo,
        x.ConteudoProgramatico.Descricao,
        x.InformacoesComplementares
    }).ToList();

    return new
    {
        Periodo = new
        {
            Turma = new
            {
                periodo.Aula.Turma.Nome
            },
            periodo.Numero,
            periodo.Status,
            QuantidadeAlunos = periodo.Aula.Turma.Alunos.Count,
            Presentes = chamadas.Count(c => c.Status == ChamadaStatus.Presente),
            Ausentes = chamadas.Count(c => c.Status == ChamadaStatus.Ausente),
            DataHoraGeracao = periodo.CreatedAt
        },
        Chamadas = chamadas,
        ConteudoAulas = conteudoAulas
    };
})
.WithName("GetChamadasAula")
.WithTags("Chamadas")
.WithOpenApi();

app.MapGet("/service/chamadas", (AppDbContext dbContext) =>
{
    return dbContext.Chamadas.ToListAsync();
})
.WithName("GetChamadas")
.WithTags("Chamadas")
.WithOpenApi();

app.MapPost("/service/chamadas", (AppDbContext dbContext, Chamada chamada) =>
{
    dbContext.Chamadas.Add(chamada);
    dbContext.SaveChanges();
    return Results.Created($"/service/chamadas/{chamada.Id}", chamada);
})
.WithName("PostChamadas")
.WithTags("Chamadas")
.WithOpenApi();

app.MapGet("/service/chamadas/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Chamadas.FindAsync(id);
})
.WithName("GetChamada")
.WithTags("Chamadas")
.WithOpenApi();

app.MapPut("/service/chamadas/{id}", (AppDbContext dbContext, Guid id, Chamada chamada) =>
{
    if (id != chamada.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(chamada).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutChamada")
.WithTags("Chamadas")
.WithOpenApi();

app.MapDelete("/service/chamadas/{id}", (AppDbContext dbContext, Guid id) =>
{
    var chamada = dbContext.Chamadas.Find(id);
    if (chamada == null)
    {
        return Results.NotFound();
    }

    dbContext.Chamadas.Remove(chamada);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteChamada")
.WithTags("Chamadas")
.WithOpenApi();

#endregion

#region "Endpoints ConteudoAula"

app.MapGet("/service/conteudoaulas", (AppDbContext dbContext) =>
{
    return dbContext.ConteudoAulas.ToListAsync();
})
.WithName("GetConteudoAulas")
.WithTags("ConteudoAulas")
.WithOpenApi();

app.MapPost("/service/conteudoaulas", (AppDbContext dbContext, ConteudoAula conteudoAula) =>
{
    dbContext.ConteudoAulas.Add(conteudoAula);
    dbContext.SaveChanges();
    return Results.Created($"/service/conteudoaulas/{conteudoAula.Id}", conteudoAula);
})
.WithName("PostConteudoAulas")
.WithTags("ConteudoAulas")
.WithOpenApi();

app.MapGet("/service/conteudoaulas/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.ConteudoAulas.FindAsync(id);
})
.WithName("GetConteudoAula")
.WithTags("ConteudoAulas")
.WithOpenApi();

app.MapPut("/service/conteudoaulas/{id}", (AppDbContext dbContext, Guid id, ConteudoAula conteudoAula) =>
{
    if (id != conteudoAula.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(conteudoAula).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutConteudoAula")
.WithTags("ConteudoAulas")
.WithOpenApi();

app.MapDelete("/service/conteudoaulas/{id}", (AppDbContext dbContext, Guid id) =>
{
    var conteudoAula = dbContext.ConteudoAulas.Find(id);
    if (conteudoAula == null)
    {
        return Results.NotFound();
    }

    dbContext.ConteudoAulas.Remove(conteudoAula);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteConteudoAula")
.WithTags("ConteudoAulas")
.WithOpenApi();

#endregion

#region "Endpoints ConteudoProgramatico"

app.MapGet("/service/conteudoprogramaticos", (AppDbContext dbContext) =>
{
    return dbContext.ConteudoProgramaticos.ToListAsync();
})
.WithName("GetConteudoProgramaticos")
.WithTags("ConteudoProgramatico")
.WithOpenApi();

app.MapPost("/service/conteudoprogramaticos", (AppDbContext dbContext, ConteudoProgramatico conteudoProgramatico) =>
{
    dbContext.ConteudoProgramaticos.Add(conteudoProgramatico);
    dbContext.SaveChanges();
    return Results.Created($"/service/conteudoprogramaticos/{conteudoProgramatico.Id}", conteudoProgramatico);
})
.WithName("PostConteudoProgramaticos")
.WithTags("ConteudoProgramatico")
.WithOpenApi();

app.MapGet("/service/conteudoprogramaticos/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.ConteudoProgramaticos.FindAsync(id);
})
.WithName("GetConteudoProgramatico")
.WithTags("ConteudoProgramatico")
.WithOpenApi();

app.MapPut("/service/conteudoprogramaticos/{id}", (AppDbContext dbContext, Guid id, ConteudoProgramatico conteudoProgramatico) =>
{
    if (id != conteudoProgramatico.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(conteudoProgramatico).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutConteudoProgramatico")
.WithTags("ConteudoProgramatico")
.WithOpenApi();

app.MapDelete("/service/conteudoprogramaticos/{id}", (AppDbContext dbContext, Guid id) =>
{
    var conteudoProgramatico = dbContext.ConteudoProgramaticos.Find(id);
    if (conteudoProgramatico == null)
    {
        return Results.NotFound();
    }

    dbContext.ConteudoProgramaticos.Remove(conteudoProgramatico);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteConteudoProgramatico")
.WithTags("ConteudoProgramatico")
.WithOpenApi();

#endregion

#region "Endpoints Curso"

app.MapGet("/service/cursos", (AppDbContext dbContext) =>
{
    return dbContext.Cursos.ToListAsync();
})
.WithName("GetCursos")
.WithTags("Curso")
.WithOpenApi();

app.MapPost("/service/cursos", (AppDbContext dbContext, Curso curso) =>
{
    dbContext.Cursos.Add(curso);
    dbContext.SaveChanges();
    return Results.Created($"/service/cursos/{curso.Id}", curso);
})
.WithName("PostCursos")
.WithTags("Curso")
.WithOpenApi();

app.MapGet("/service/cursos/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Cursos.FindAsync(id);
})
.WithName("GetCurso")
.WithTags("Curso")
.WithOpenApi();

app.MapPut("/service/cursos/{id}", (AppDbContext dbContext, Guid id, Curso curso) =>
{
    if (id != curso.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(curso).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutCurso")
.WithTags("Curso")
.WithOpenApi();

app.MapDelete("/service/cursos/{id}", (AppDbContext dbContext, Guid id) =>
{
    var curso = dbContext.Cursos.Find(id);
    if (curso == null)
    {
        return Results.NotFound();
    }

    dbContext.Cursos.Remove(curso);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteCurso")
.WithTags("Curso")
.WithOpenApi();

#endregion

#region "Endpoints Disciplina"

app.MapGet("/service/disciplinas", (AppDbContext dbContext) =>
{
    return dbContext.Disciplinas.ToListAsync();
})
.WithName("GetDisciplinas")
.WithTags("Disciplina")
.WithOpenApi();

app.MapPost("/service/disciplinas", (AppDbContext dbContext, Disciplina disciplina) =>
{
    dbContext.Disciplinas.Add(disciplina);
    dbContext.SaveChanges();
    return Results.Created($"/service/disciplinas/{disciplina.Id}", disciplina);
})
.WithName("PostDisciplinas")
.WithTags("Disciplina")
.WithOpenApi();

app.MapGet("/service/disciplinas/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Disciplinas.FindAsync(id);
})
.WithName("GetDisciplina")
.WithTags("Disciplina")
.WithOpenApi();

app.MapPut("/service/disciplinas/{id}", (AppDbContext dbContext, Guid id, Disciplina disciplina) =>
{
    if (id != disciplina.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(disciplina).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutDisciplina")
.WithTags("Disciplina")
.WithOpenApi();

app.MapDelete("/service/disciplinas/{id}", (AppDbContext dbContext, Guid id) =>
{
    var disciplina = dbContext.Disciplinas.Find(id);
    if (disciplina == null)
    {
        return Results.NotFound();
    }

    dbContext.Disciplinas.Remove(disciplina);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteDisciplina")
.WithTags("Disciplina")
.WithOpenApi();

#endregion

#region "Endpoints Periodo"

app.MapGet("/service/periodos", (AppDbContext dbContext) =>
{
    return dbContext.Periodos.ToListAsync();
})
.WithName("GetPeriodos")
.WithTags("Periodo")
.WithOpenApi();

app.MapPost("/service/periodos", (AppDbContext dbContext, Periodo periodo) =>
{
    dbContext.Periodos.Add(periodo);
    dbContext.SaveChanges();
    return Results.Created($"/service/periodos/{periodo.Id}", periodo);
})
.WithName("PostPeriodos")
.WithTags("Periodo")
.WithOpenApi();

app.MapGet("/service/periodos/{id}", (AppDbContext dbContext, Guid id) =>
{
    return dbContext.Periodos.FindAsync(id);
})
.WithName("GetPeriodo")
.WithTags("Periodo")
.WithOpenApi();

app.MapPut("/service/periodos/{id}", (AppDbContext dbContext, Guid id, Periodo periodo) =>
{
    if (id != periodo.Id)
    {
        return Results.BadRequest();
    }

    dbContext.Entry(periodo).State = EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("PutPeriodo")
.WithTags("Periodo")
.WithOpenApi();

app.MapDelete("/service/periodos/{id}", (AppDbContext dbContext, Guid id) =>
{
    var periodo = dbContext.Periodos.Find(id);
    if (periodo == null)
    {
        return Results.NotFound();
    }

    dbContext.Periodos.Remove(periodo);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeletePeriodo")
.WithTags("Periodo")
.WithOpenApi();

#endregion

app.Run();
