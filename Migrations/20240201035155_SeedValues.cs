using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciamentoPresenca.Migrations
{
    /// <inheritdoc />
    public partial class SeedValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "CreatedAt", "Nome", "RM", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9700), "Leonardo", "RM347972", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9699), "Lucas", "RM348290", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9698), "Vinicius", "RM347982", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9684), "Felipe", "RM347765", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "CreatedAt", "Nome", "Sigla", "UpdatedAt" },
                values: new object[] { new Guid("65a96013-2da3-4db1-8653-965660d1d49e"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9713), "ARQUITETURA E DESENVOLVIMENTO .NET", "ARCHNET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "CreatedAt", "Nome", "RM", "UpdatedAt" },
                values: new object[] { new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9702), "Ricardo", "PF1931", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CreatedAt", "CursoId", "Nome", "ProfessorId", "UpdatedAt" },
                values: new object[] { new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9730), new Guid("65a96013-2da3-4db1-8653-965660d1d49e"), "Arquitetura de Banco de Dados e Persistência", new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Code", "CreatedAt", "CursoId", "Nome", "UpdatedAt" },
                values: new object[] { new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), "2NETR", new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9715), new Guid("65a96013-2da3-4db1-8653-965660d1d49e"), "Turma 2NETR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Aulas",
                columns: new[] { "Id", "CreatedAt", "Data", "DisciplinaId", "Status", "TurmaId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9768), new DateOnly(2024, 2, 8), new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), 0, new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9778), new DateOnly(2024, 2, 15), new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), 0, new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9740), new DateOnly(2024, 2, 1), new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), 0, new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ConteudoProgramaticos",
                columns: new[] { "Id", "Codigo", "CreatedAt", "Descricao", "DisciplinaId", "Nome", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("37eb7b3b-c267-4ce5-81d1-26696ec7bbb0"), 1, new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9734), "Conceitos iniciais de banco de dados", new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), "Introdução a banco de dados", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5791e766-86cf-4050-ad8d-6857770cf844"), 3, new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9738), "Linguagem SQL", new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), "SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5bebda5c-46f9-4e34-849b-dd433924b496"), 2, new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9737), "Modelagem de dados com MER", new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"), "Modelagem de dados", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TurmaAlunos",
                columns: new[] { "Id", "AlunoId", "CreatedAt", "TurmaId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1d276cde-39c7-4763-b47d-ac31a3c11510"), new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9728), new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b08363e-e98a-4306-a223-2295ddb70cbf"), new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9726), new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64f17d88-bc41-499c-a3d3-485d8011cea1"), new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9727), new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9aa2881e-966f-4f8e-b792-b6bd5d7c2811"), new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9727), new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ConteudoAulas",
                columns: new[] { "Id", "AulaId", "ConteudoProgramaticoId", "CreatedAt", "InformacoesComplementares", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("75c8abab-68e7-49bb-835d-bb577aa81de3"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new Guid("5791e766-86cf-4050-ad8d-6857770cf844"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9779), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab0752c9-76a4-4e18-856c-544d4684682a"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new Guid("37eb7b3b-c267-4ce5-81d1-26696ec7bbb0"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9750), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7079733-319b-41a9-a9d1-7ba3332788e2"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new Guid("5bebda5c-46f9-4e34-849b-dd433924b496"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9769), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Periodos",
                columns: new[] { "Id", "AulaId", "CreatedAt", "HoraFim", "HoraInicio", "Numero", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1eb477bb-fbd0-4748-a50b-4feb2ec22c9f"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9771), new TimeOnly(22, 45, 0), new TimeOnly(21, 20, 0), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("521f2e83-3ba0-48a4-8cca-2532d8a94788"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9759), new TimeOnly(22, 45, 0), new TimeOnly(21, 20, 0), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53635734-66bb-4716-a32c-9534047150cc"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9780), new TimeOnly(21, 0, 0), new TimeOnly(19, 0, 0), 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("777ecda3-2feb-4fc0-bfb9-94b1abb57468"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9781), new TimeOnly(22, 45, 0), new TimeOnly(21, 20, 0), 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9770), new TimeOnly(21, 0, 0), new TimeOnly(19, 0, 0), 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9753), new TimeOnly(21, 0, 0), new TimeOnly(19, 0, 0), 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Chamadas",
                columns: new[] { "Id", "AlunoId", "AulaId", "CreatedAt", "PeriodoId", "ProfessorId", "Status", "TipoPresenca", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("13b04fcc-9513-421a-ba08-9eaf0d8b25d4"), new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9787), new Guid("53635734-66bb-4716-a32c-9534047150cc"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36907b91-9fd4-480a-a117-7832d42fd4aa"), new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9763), new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("43c4a6f7-8238-4d61-b010-b0b5cc14cdf2"), new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9777), new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4cc39b00-c7a6-42a0-9763-045b47d29895"), new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9772), new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("529bdb30-0973-4363-a7e1-287580c0f603"), new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9784), new Guid("53635734-66bb-4716-a32c-9534047150cc"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8cd02a8c-9f38-47dd-8c32-226fccc419f2"), new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9767), new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b803c7ed-9b9a-4d41-ab72-9cfeff03fd47"), new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9773), new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cf1aeabc-bf07-421c-a03d-bce58ef12c24"), new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9786), new Guid("53635734-66bb-4716-a32c-9534047150cc"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d52da1d3-4871-4a02-ac7e-168436980df4"), new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9760), new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3c040c7-bc72-44fc-8917-993bd4af3ef6"), new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"), new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9782), new Guid("53635734-66bb-4716-a32c-9534047150cc"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e43fcb4e-fc57-4c72-a54d-5c041989df1e"), new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"), new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9776), new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e631486d-84d4-4296-8087-c59d72302c6b"), new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"), new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"), new DateTime(2024, 2, 1, 0, 51, 55, 519, DateTimeKind.Local).AddTicks(9766), new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"), new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"), 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("13b04fcc-9513-421a-ba08-9eaf0d8b25d4"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("36907b91-9fd4-480a-a117-7832d42fd4aa"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("43c4a6f7-8238-4d61-b010-b0b5cc14cdf2"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("4cc39b00-c7a6-42a0-9763-045b47d29895"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("529bdb30-0973-4363-a7e1-287580c0f603"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("8cd02a8c-9f38-47dd-8c32-226fccc419f2"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("b803c7ed-9b9a-4d41-ab72-9cfeff03fd47"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("cf1aeabc-bf07-421c-a03d-bce58ef12c24"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("d52da1d3-4871-4a02-ac7e-168436980df4"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("e3c040c7-bc72-44fc-8917-993bd4af3ef6"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("e43fcb4e-fc57-4c72-a54d-5c041989df1e"));

            migrationBuilder.DeleteData(
                table: "Chamadas",
                keyColumn: "Id",
                keyValue: new Guid("e631486d-84d4-4296-8087-c59d72302c6b"));

            migrationBuilder.DeleteData(
                table: "ConteudoAulas",
                keyColumn: "Id",
                keyValue: new Guid("75c8abab-68e7-49bb-835d-bb577aa81de3"));

            migrationBuilder.DeleteData(
                table: "ConteudoAulas",
                keyColumn: "Id",
                keyValue: new Guid("ab0752c9-76a4-4e18-856c-544d4684682a"));

            migrationBuilder.DeleteData(
                table: "ConteudoAulas",
                keyColumn: "Id",
                keyValue: new Guid("d7079733-319b-41a9-a9d1-7ba3332788e2"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("1eb477bb-fbd0-4748-a50b-4feb2ec22c9f"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("521f2e83-3ba0-48a4-8cca-2532d8a94788"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("777ecda3-2feb-4fc0-bfb9-94b1abb57468"));

            migrationBuilder.DeleteData(
                table: "TurmaAlunos",
                keyColumn: "Id",
                keyValue: new Guid("1d276cde-39c7-4763-b47d-ac31a3c11510"));

            migrationBuilder.DeleteData(
                table: "TurmaAlunos",
                keyColumn: "Id",
                keyValue: new Guid("5b08363e-e98a-4306-a223-2295ddb70cbf"));

            migrationBuilder.DeleteData(
                table: "TurmaAlunos",
                keyColumn: "Id",
                keyValue: new Guid("64f17d88-bc41-499c-a3d3-485d8011cea1"));

            migrationBuilder.DeleteData(
                table: "TurmaAlunos",
                keyColumn: "Id",
                keyValue: new Guid("9aa2881e-966f-4f8e-b792-b6bd5d7c2811"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("0bb2ebe3-072c-4c4c-99ee-3ceea556d09d"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("3bb1284a-3f5a-4b23-aea8-e30989d900da"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("94ec29f4-1354-4b70-95ac-7591827e7042"));

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: new Guid("b3f27cb7-85b1-44e0-b0e6-352aed88b934"));

            migrationBuilder.DeleteData(
                table: "ConteudoProgramaticos",
                keyColumn: "Id",
                keyValue: new Guid("37eb7b3b-c267-4ce5-81d1-26696ec7bbb0"));

            migrationBuilder.DeleteData(
                table: "ConteudoProgramaticos",
                keyColumn: "Id",
                keyValue: new Guid("5791e766-86cf-4050-ad8d-6857770cf844"));

            migrationBuilder.DeleteData(
                table: "ConteudoProgramaticos",
                keyColumn: "Id",
                keyValue: new Guid("5bebda5c-46f9-4e34-849b-dd433924b496"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("53635734-66bb-4716-a32c-9534047150cc"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("98b04988-ce51-46eb-8ed1-c810d006d977"));

            migrationBuilder.DeleteData(
                table: "Periodos",
                keyColumn: "Id",
                keyValue: new Guid("c95a4c51-803e-4c29-9fab-cba15ec55791"));

            migrationBuilder.DeleteData(
                table: "Aulas",
                keyColumn: "Id",
                keyValue: new Guid("9067cc83-0acb-4da3-b799-56693ddf5aac"));

            migrationBuilder.DeleteData(
                table: "Aulas",
                keyColumn: "Id",
                keyValue: new Guid("d68dbef7-686c-4309-b2eb-d05ce0f36a04"));

            migrationBuilder.DeleteData(
                table: "Aulas",
                keyColumn: "Id",
                keyValue: new Guid("f090a5e9-dd0b-4d81-94f9-e8186f7fc4f4"));

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: new Guid("4fd8a2af-7a30-4d99-82d8-15a3f771f642"));

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("b283b178-8492-4cd6-9b88-bf0b000c6125"));

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "Id",
                keyValue: new Guid("65a96013-2da3-4db1-8653-965660d1d49e"));

            migrationBuilder.DeleteData(
                table: "Professores",
                keyColumn: "Id",
                keyValue: new Guid("f8d01e2f-7030-4ea7-9eee-9f83042041c0"));
        }
    }
}
