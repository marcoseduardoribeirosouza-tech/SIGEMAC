using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class EstadoDAO
    {
        private readonly Conexao _conexao;
        public EstadoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Estado> Listar()
        {
            try
            {
                var lista = new List<Estado>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM estado";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var estado = new Estado();
                    estado.Id = leitor.GetInt32("id_est");
                    estado.Nome = leitor.GetString("nome_est");
                    estado.Sigla = leitor.GetString("sigla_est");

                    lista.Add(estado);
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