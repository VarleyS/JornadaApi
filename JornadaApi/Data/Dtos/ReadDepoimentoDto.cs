using System.ComponentModel.DataAnnotations;

namespace JornadaApi.Data.Dtos
{
    public class ReadDepoimentoDto
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string RegistroDepoimento { get; set; }
        public DateTime HoraConsulta { get; set; } = DateTime.Now;
    }
}
