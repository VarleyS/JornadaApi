using JornadaApi.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace JornadaApi.Models
{
    public class Depoimento
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        public string? Foto { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string RegistroDepoimento { get; set; }
    }
}
