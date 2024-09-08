using Microsoft.EntityFrameworkCore;
using Ucode.Api.Data;
using Ucode.Api.Handlers;
using Ucode.Core.Handlers;
using Ucode.Core.Models;
using Ucode.Core.Requests.Alunos;
using Ucode.Core.Requests.Curso;
using Ucode.Core.Responses;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>( x =>
{
    x.UseSqlServer(cnnStr);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});

builder.Services.AddTransient<IAlunoHandler,AlunoHandler>();
builder.Services.AddTransient<ICursoHandler,CursoHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/v1/cursos",
    
     async (CreateCursoRequest request,
     ICursoHandler handler)
     => await handler.CreateAsync(request))
    .WithName("Cursos: Create")
    .WithSummary("Criar um novo curso")
    .Produces<Response<Curso>>();
app.MapPut("/v1/cursos/{id}",
    async (long id,
            UpdateCursoRequest request,
            ICursoHandler handler)
         =>
    {
        request.Id = id;
        return await handler.UpdateAsync(request);
    })
    .WithName("Cursos: Update")
    .WithSummary("Atualizar um curso")
    .Produces<Response<Curso?>>();

app.MapDelete("/v1/cursos/{id}",
    async (long id,
     ICursoHandler handler)
     =>
    {
        var request = new DeleteCursoRequest
        {
            Id = id,
            UserId = "test@balta.io"
        };

        return await handler.DeleteAsync(request);
    })
    .WithName("Cursos: Delete")
    .WithSummary("Excluir um curso")
    .Produces<Response<Curso?>>();

app.MapGet("/v1/alunos/{id}",
    async (long id,
     ICursoHandler handler)
     =>
    {
        var request = new GetCursoByIdRequest
        {
            Id = id,
            UserId = "test@balta.io"
        };

        return await handler.GetByIdAsync(request);
    })
    .WithName("Alunos: Get By Id")
    .WithSummary("Retorna um aluno")
    .Produces<Response<Curso?>>();

app.MapGet("/v1/alunos",
    async (
     ICursoHandler handler)
     =>
    {
        var request = new GetAllCursoRequest
        {

            UserId = "test@balta.io"
        };

        return await handler.GetAllAsync(request);
    })
    .WithName("Cursos: Get All")
    .WithSummary("Retorna todos os cursos de um usuário")
    .Produces<PagedResponse<List<Curso>?>>();


app.Run();
