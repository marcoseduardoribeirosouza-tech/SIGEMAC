using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class FornecedorDAO
    {
        private readonly Conexao _conexao;
        public FornecedorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Fornecedor> Listar()
        {
            var lista = new List<Fornecedor>();

            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM fornecedor";
            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var fornecedor = new Fornecedor();
                fornecedor.Id = leitor.GetInt32("id_forn");
                fornecedor.Nome = leitor.GetString("nome_forn");
                fornecedor.Cnpj = leitor.GetString("cnpj_forn");
                fornecedor.Telefone = leitor.GetString("telefone_forn");
                fornecedor.Email = leitor.GetString("email_forn");

                lista.Add(fornecedor);
            }

            return lista;
        }
    }
}
