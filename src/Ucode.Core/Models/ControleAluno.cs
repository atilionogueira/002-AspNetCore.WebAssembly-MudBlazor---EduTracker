﻿
namespace Ucode.Core.Models
{
    public class ControleAluno
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public string Resumo { get; set; } = string.Empty;

        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;
        public long CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
        public long ModuloId { get; set; }
        public Modulo Mudulo { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;

       

    }
}
