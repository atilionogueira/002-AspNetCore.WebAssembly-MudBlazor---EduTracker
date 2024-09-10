using Microsoft.EntityFrameworkCore;
using Ucode.Api.Data;
using Ucode.Api.Endpoints;
using Ucode.Api.Handlers;
using Ucode.Core.Handlers;

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
builder.Services.AddTransient<IModuloHandler, ModuloHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/",() => new { message = "OK" });
app.MapEndpoint();

app.Run();
