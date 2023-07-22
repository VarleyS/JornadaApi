using JornadaApi.Models;
using JornadaApi.Util;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;

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

        public void SalvaDepoimentoComImagem(string depoimentoNome, string imagemPara, string registroDepoimento)
        {
            string imagemBase64 = ImagemConvert.ConvertImagemParaString(imagemPara);

            Depoimento depoimento = new Depoimento
            {
                Nome = depoimentoNome,
                Foto = imagemPara,
                RegistroDepoimento = registroDepoimento
            };
        }
    }
}
