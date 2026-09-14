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
                fornecedor.Id_forn = leitor.GetInt32("id_forn");
                fornecedor.nome_forn = leitor.GetString("nome_forn");
                fornecedor.cnpj_forn = leitor.GetString("cnpj_forn");
                fornecedor.telefone_forn = leitor.GetString("telefone_forn");
                fornecedor.email_forn = leitor.GetString("email_forn");
            }

            return lista;
        }
    }
}
