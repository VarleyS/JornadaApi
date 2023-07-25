using JornadaApi.Models;
using JornadaApi.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;

namespace JornadaApi.Data.Dtos
{
    public class CreateDepoimentoDto
    {
        private ImagemConvert _imagemConvert;

        public CreateDepoimentoDto(ImagemConvert imagemConvert)
        {
            _imagemConvert = imagemConvert;
        }
        public CreateDepoimentoDto()
        {
        }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        public string? Foto { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Tamanho máximo de 500 caracteres.")]
        public string RegistroDepoimento { get; set; }

        [NotMapped]
        public IFormFile Imagem { get; set; }

        public void SalvaDepoimentoComImagem(string depoimentoNome, IFormFile imagemPara, string registroDepoimento)
        {
            string imagemBase64 = _imagemConvert.ConvertImagemParaString(imagemPara);

            Depoimento depoimento = new Depoimento
            {
                Nome = depoimentoNome,
                Foto = imagemBase64,
                RegistroDepoimento = registroDepoimento
            };
        }
    }
}
