namespace sigemac.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public Cidade Cidade { get; set; }

    }
}