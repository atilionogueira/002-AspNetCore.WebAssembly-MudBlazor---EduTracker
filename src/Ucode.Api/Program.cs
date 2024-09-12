using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ucode.Api.Data;
using Ucode.Api.Endpoints;
using Ucode.Api.Handlers;
using Ucode.Api.Models;
using Ucode.Core.Handlers;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies(); // JWT Bearer
builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>( x =>
{
    x.UseSqlServer(cnnStr);
});

builder.Services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>() // Adicionar as tabelas no BD
    .AddApiEndpoints();  

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds(n => n.FullName);
});


builder.Services.AddTransient<IAlunoHandler,AlunoHandler>();
builder.Services.AddTransient<ICursoHandler,CursoHandler>();
builder.Services.AddTransient<IModuloHandler, ModuloHandler>();
builder.Services.AddTransient<IControleAlunoHandler, ControleAlunoHandler>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/",() => new { message = "OK" });
app.MapEndpoint();

app.Run();
