# 3_4_Endpoints_para_Gerenciamento_Presenca
Projeto usado na aula  3 e 4 da disciplina ARQUITETURA DE BANCO DE DADOS E PERSISTÊNCIA da turma 2NETR - FIAP

# Gerenciamento de Presença

## Descrição
O projeto **Gerenciamento de Presença** é uma aplicação web desenvolvida em ASP.NET Core que oferece funcionalidades para o gerenciamento de presença em instituições educacionais. Ele fornece uma API RESTful para criar, atualizar, ler e excluir registros relacionados a alunos, professores, disciplinas, turmas, aulas e presença dos alunos.

## Funcionalidades Principais
- Gerenciamento de alunos
- Gerenciamento de professores
- Gerenciamento de disciplinas
- Gerenciamento de turmas
- Registro de presença dos alunos
- Consulta de presença por aula e período

## Requisitos do Sistema
- .NET Core SDK 3.1 ou superior
- SQL Server (ou outro banco de dados suportado pelo Entity Framework Core)

## Configuração do Projeto
1. Clone este repositório para o seu ambiente local.
2. Certifique-se de ter o .NET Core SDK instalado em sua máquina.
3. Abra o projeto no Visual Studio ou em sua IDE preferida.
4. Configure a conexão com o banco de dados no arquivo `appsettings.json`.
5. Execute as migrações do banco de dados utilizando o comando `dotnet ef database update` no terminal.

## Executando o Projeto
1. Compile o projeto.
2. Inicie a aplicação.
3. Acesse a API através do navegador ou de ferramentas como Postman ou Insomnia.

## Endpoints da API
O projeto oferece os seguintes endpoints:

- `/api/alunos`: CRUD de alunos.
- `/api/professores`: CRUD de professores.
- `/api/disciplinas`: CRUD de disciplinas.
- `/api/turmas`: CRUD de turmas.
- `/api/aulas`: CRUD de aulas.
- `/api/chamadas`: CRUD de registros de presença dos alunos.
- `/api/conteudoaulas`: CRUD de conteúdo das aulas.
- `/api/conteudoprogramaticos`: CRUD de conteúdo programático.
- `/api/periodos`: CRUD de períodos de aulas.

## SwaggerGen

![image](https://github.com/LucasSebrian/3_4_Endpoints_para_Gerenciamento_Presenca/assets/40295405/d6827a13-7974-4921-a7a8-e1d79d850970)

![image](https://github.com/LucasSebrian/3_4_Endpoints_para_Gerenciamento_Presenca/assets/40295405/487039ab-efd6-4414-9c30-24f86fa4b803)

