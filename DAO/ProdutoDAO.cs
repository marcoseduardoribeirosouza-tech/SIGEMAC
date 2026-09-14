using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class ProdutoDAO
    {
        private readonly Conexao _conexao;
        public ProdutoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Produto> Listar()
        {
            var lista = new List<Produto>();

            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM produto left join fornecedor on (id_forn_fk = id_forn);";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = leitor.GetString("nome_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Preco = leitor.GetDecimal("preco_pro");
                produto.Descricao = leitor.GetString("descricao_pro");

                var fornecedor = new Fornecedor();
                fornecedor.Id = leitor.GetInt32("id_forn");
                fornecedor.Nome = leitor.GetString("nome_forn");
                produto.Fornecedor = fornecedor;
            }

            return lista;
        }
    }
}
