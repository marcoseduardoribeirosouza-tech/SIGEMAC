namespace sigemac.Models
{
	public class Entregador
	{
		public int Id { get; set; }
		public string Nome { get; set; } =string.Empty;
		public string Telefone { get; set; } =string.Empty;
		public string CNH { get; set; } = string.Empty;	
		public DateTime DataNascimento { get; set; }
		public DateTime DataCadastro { get; set; }
		public string Descricao { get; set; } = string.Empty;	

	}
}
