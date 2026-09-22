namespace sigemac.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public Estado Estado { get; set; }

    }
}