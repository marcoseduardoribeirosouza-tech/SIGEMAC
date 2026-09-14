namespace SIGEMAC.Model
{
    public class Venda
    {

        public int Id { get; set; }
        public DateOnly Data_Registro { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public Entregador Entregador { get; set; }

    }
}