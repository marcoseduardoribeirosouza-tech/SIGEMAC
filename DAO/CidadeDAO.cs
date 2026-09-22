using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class CidadeDAO
    {
        private readonly Conexao _conexao;
        public CidadeDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cidade> Listar()
        {
            try
            {
                var lista = new List<Cidade>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM cidade left join estado on (id_est = id_est_fk)";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var cidade = new Cidade();
                    cidade.Id = leitor.GetInt32("id_cid");
                    cidade.Nome = leitor.GetString("nome_cid");

                    var estado = new Estado();
                    estado.Id = leitor.GetInt32("id_est");
                    estado.Nome = leitor.GetString("nome_est");
                    estado.Sigla = leitor.GetString("sigla_est");
                    cidade.Estado = estado;

                    lista.Add(cidade);
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