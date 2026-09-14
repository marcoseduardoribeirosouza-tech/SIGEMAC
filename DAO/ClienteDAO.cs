using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;
        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> Listar()
        {
            try
            {
                var lista = new List<Cliente>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM cliente";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var cliente = new Cliente();
                    cliente.Id = leitor.GetInt32("id.cli");
                    cliente.Nome = leitor.GetString("nome_cli");
                    cliente.Email = leitor.GetString("email_cli");
                    cliente.Telefone = leitor.GetString("telefone_cli");
                    cliente.Observacao = leitor.GetString("observacao_cli");
                    cliente.Cpf = leitor.GetString("cpf_cli");
                    cliente.Endereco = leitor.GetString("id_end_fk");
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}
