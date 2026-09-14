namespace sigemac.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; } 
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public Fornecedor Fornecedor { get; set; }

    }
}
