using System.ComponentModel.DataAnnotations;

namespace sigemac.Models
{
    public class Venda
    {



        public int Id { get; set; }
        [Required(ErrorMessage = "O número do processo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O número deve ter no máximo 200 caracteres.")]
        public string Numero { get; set; } = string.Empty;
        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateOnly? DataRegistro { get; set; }
        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [StringLength(200, ErrorMessage = "O cliente deve ter no máximo 200 caracteres.")]
        public Cliente Cliente { get; set; }
        [Required(ErrorMessage = "O produto é obrigatório.")]
        [StringLength(300, ErrorMessage = "O produto deve ter no máximo 300 caracteres.")]
        public Produto Produto { get; set; }
        [StringLength(2000, ErrorMessage = "A descrição deve ter no máximo 2000 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "o Entregador é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Entregador deve ter no máximo 50 caracteres.")]
        public Entregador Entregador { get; set; }

    }
}