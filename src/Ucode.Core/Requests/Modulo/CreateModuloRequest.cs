
using System.ComponentModel.DataAnnotations;

namespace Ucode.Core.Requests.Modulo
{
    public class CreateModuloRequest
    {
        [Required(ErrorMessage = "Título inválido")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Data inválida")]
        public DateTime DataInicio { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Data inválida")]
        public DateTime? DataFim { get; set; }

        [Required]
        public string Resumo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Curso Inválido")]
        public long CursoId { get; set; }

    }
}
