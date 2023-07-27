using JornadaApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;

namespace JornadaApi.Data.Dtos
{
    public class CreateDepoimentoDto
    {
        public CreateDepoimentoDto()
        {
        }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        public string? Foto { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string RegistroDepoimento { get; set; }

        [NotMapped]
        public byte[]? FotoBase64 { get; internal set; }
    }
}
