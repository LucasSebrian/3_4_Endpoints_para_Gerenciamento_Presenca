﻿// <auto-generated />
using System;
using GerenciamentoPresenca.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoPresenca.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240201033655_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Aula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<Guid>("DisciplinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aulas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Chamada", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AulaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PeriodoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TipoPresenca")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("AulaId");

                    b.HasIndex("PeriodoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Chamadas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.ConteudoAula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AulaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConteudoProgramaticoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InformacoesComplementares")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.HasIndex("ConteudoProgramaticoId");

                    b.ToTable("ConteudoAulas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.ConteudoProgramatico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DisciplinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("ConteudoProgramaticos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Periodo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AulaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AulaId");

                    b.ToTable("Periodos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.TurmaAluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("TurmaAlunos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Aula", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Disciplina", "Disciplina")
                        .WithMany("Aulas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Turma", "Turma")
                        .WithMany("Aulas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Chamada", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Aluno", "Aluno")
                        .WithMany("Chamadas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Aula", "Aula")
                        .WithMany("Chamadas")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Periodo", "Periodo")
                        .WithMany("Chamadas")
                        .HasForeignKey("PeriodoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Professor", "Professor")
                        .WithMany("Chamadas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Aula");

                    b.Navigation("Periodo");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.ConteudoAula", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Aula", "Aula")
                        .WithMany("Conteudos")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.ConteudoProgramatico", "ConteudoProgramatico")
                        .WithMany("Aulas")
                        .HasForeignKey("ConteudoProgramaticoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("ConteudoProgramatico");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.ConteudoProgramatico", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Disciplina", "Disciplina")
                        .WithMany("ConteudosProgramaticos")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Disciplina", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Periodo", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Turma", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.TurmaAluno", b =>
                {
                    b.HasOne("GerenciamentoPresenca.Entities.Aluno", "Aluno")
                        .WithMany("Turmas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoPresenca.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Aluno", b =>
                {
                    b.Navigation("Chamadas");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Aula", b =>
                {
                    b.Navigation("Chamadas");

                    b.Navigation("Conteudos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.ConteudoProgramatico", b =>
                {
                    b.Navigation("Aulas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Disciplina", b =>
                {
                    b.Navigation("Aulas");

                    b.Navigation("ConteudosProgramaticos");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Periodo", b =>
                {
                    b.Navigation("Chamadas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Professor", b =>
                {
                    b.Navigation("Chamadas");

                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("GerenciamentoPresenca.Entities.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Aulas");
                });
#pragma warning restore 612, 618
        }
    }
}
