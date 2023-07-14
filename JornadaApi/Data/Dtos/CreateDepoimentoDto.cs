using System.ComponentModel.DataAnnotations;

namespace JornadaApi.Data.Dtos
{
    public class CreateDepoimentoDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string RegistroDepoimento { get; set; }
    }
}
