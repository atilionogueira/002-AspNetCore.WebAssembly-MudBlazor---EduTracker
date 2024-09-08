using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ucode.Core.Models;

namespace Ucode.Api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<ControleAluno> ControleAlunos { get; set; } = null!;
        public DbSet<Curso> Cursos { get; set; } = null!;
        public DbSet<Modulo> Modulos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        }
    }
}
