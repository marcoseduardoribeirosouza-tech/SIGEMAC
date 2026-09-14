using System.Security.Cryptography.Xml;

namespace sigemac.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateOnly Data { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Observacao {  get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public Endereco Endereco { get; set; }
        
    }
}
