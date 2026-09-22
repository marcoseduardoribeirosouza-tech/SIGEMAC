using sigemac.Configs;
using sigemac.Models;
using System.Data;

namespace sigemac.DAO
{
	public class EntregadorDAO
	{
		private readonly Conexao _conexao;
		public EntregadorDAO(Conexao conexao)
		{
			_conexao = conexao;
		}

		public List<Entregador> Listar()
		{
			var lista = new List<Entregador>();

			using var con = _conexao.GetConnection();

			string sql = "SELECT * FROM entregador";
			using var comando = con.CreateCommand();
			comando.CommandText = sql;

			using var leitor = comando.ExecuteReader();

			while (leitor.Read())
			{
				var Entregador = new Entregador();
				Entregador.Id = leitor.GetInt32("id_entr");
				Entregador.Nome = leitor.GetString("nome_entr");
				Entregador.Telefone = leitor.GetString("telefone_entr");
				Entregador.CNH = leitor.GetString("cnh_entr");
				Entregador.Descricao = leitor.GetString("descricao_entr");
				Entregador.DataNascimento = leitor.GetDateTime("data_nasc_entr");
				Entregador.DataCadastro = leitor.GetDateTime("data_cadastro_entr");

				lista.Add(Entregador);
			}

			return lista;
		}
	}
}
