using Ucode.Core.Enums;

namespace Ucode.Core.Models
{
    public class Curso
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ECursoCategoria Categoria { get; set; }
        public string Resumo { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;  
        
        public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();
        public virtual ICollection<ControleAluno> ControleAlunos { get; set; } = new List<ControleAluno>();
    }
}
