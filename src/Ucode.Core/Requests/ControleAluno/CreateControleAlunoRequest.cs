
using System.ComponentModel.DataAnnotations;

namespace Ucode.Core.Requests.ControleAluno
{
    public class CreateControleAlunoRequest
    {
        [Required(ErrorMessage = "Data inválida")]
        public DateTime Data { get; set; }

        [Required()]
        public string Resumo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Aluno inválido")]
        public long AlunoId { get; set; }

        [Required(ErrorMessage = "Curso inválido")]
        public long CursoId { get; set; }

        [Required(ErrorMessage = "Modulo inválido")]
        public long ModuloId { get; set; }
      
    }
}
