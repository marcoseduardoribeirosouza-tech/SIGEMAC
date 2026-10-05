using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace sigemac.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public Cliente Cliente { get; set; }
        public Venda Venda { get; set; }
        public Entregador Entregador { get; set; }
        public Produto Produto { get; set; }
        public Fornecedor Fornecedor { get; set; }



    }
}
