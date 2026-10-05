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

            string sql = "SELECT * FROM produto inner join fornecedor on (id_forn_fk = id_forn);";
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

                lista.Add(produto);
            }

            return lista;
        }

        public void Inserir(Produto produto)
        {
            using var con = _conexao.GetConnection();

            string sql = "INSERT INTO produto (nome_pro, quantidade_pro, preco_pro, descricao_pro) VALUES (@nome, @quantidade, @preco, @descricao)";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            comando.Parameters.AddWithValue("@nome", produto.Nome);
            comando.Parameters.AddWithValue("@quantidade", produto.Quantidade);
            comando.Parameters.AddWithValue("@preco", produto.Preco);
            comando.Parameters.AddWithValue("@descricao", produto.Descricao);

            comando.ExecuteNonQuery();
        }
    }
}
