using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PapaiNoel.Models
{
    public class DadosCartinhas
    {
        [Required(ErrorMessage = "O Nome é obrigatória.")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "O Nome deve ter no maximo 255 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Infome o nome da Rua/Avenida.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Informe o numero de sua residencia.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Informe seu bairro.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe sua cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo idade é obrigatório.")]
        [Range(0, 15, ErrorMessage = "Somente maiores de 15 anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo em questão é obrigatório.")]
        [MaxLength(500, ErrorMessage = "O Número máximo de carateres atingido(500).")]
        public string TextoCarta { get; set; }

    }
}
