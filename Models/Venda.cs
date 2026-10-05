using System.ComponentModel.DataAnnotations;

namespace sigemac.Models
{
    public class Venda
    {



        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public DateOnly? DataRegistro { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Entregador Entregador { get; set; }

    }
}