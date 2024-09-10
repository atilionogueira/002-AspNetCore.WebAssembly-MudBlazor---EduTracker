namespace Ucode.Core.Models
{
    public class Modulo
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;       
        public string Resumo { get; set; } = string.Empty;
        public long CursoId { get; set; }
        public Curso Curso { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;              
   

    }
}
