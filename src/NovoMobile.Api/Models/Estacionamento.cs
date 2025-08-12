using System.ComponentModel.DataAnnotations;

namespace NovoMobile.Api.Models
{
    /// <summary>
    /// Propriedades do produto.
    /// </summary>
    public class Estacionamento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Necessário informar placa.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve possuir exatamente 7 caracteres.")]
        public string? Placa { get; set; }

        [Required(ErrorMessage = "Necessário informar modelo.")]
        [StringLength(50, ErrorMessage = "O modelo deve ter no máximo 50 caracteres.")]
        public string? Modelo { get; set; }

        [StringLength(200, ErrorMessage = "A Observação deve ter no máximo 200 caracteres.")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Necessário informar a data de entrada.")]
        public DateTime DataEntrada { get; set; }

        public DateTime? DataSaida { get; set; } 
    }
} 
