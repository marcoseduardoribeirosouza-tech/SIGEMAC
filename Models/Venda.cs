namespace sigemac.Models
{
    public class Venda
    {

        public int Id { get; set; }
        public DateTime Data_Registro { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public Entregador Entregador { get; set; }

    }
}