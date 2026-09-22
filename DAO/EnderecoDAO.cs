using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class EnderecoDAO
    {
        private readonly Conexao _conexao;
        public EnderecoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Endereco> Listar()
        {
            try
            {
                var lista = new List<Endereco>();

                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM endereco LEFT JOIN cidade ON (id_cid_fk = id_cid) LEFT JOIN estado ON (id_est_fk = id_est);";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var endereco = new Endereco();
                    endereco.Id = leitor.GetInt32("id_end");
                    endereco.Numero = leitor.GetInt32("numero_end");
                    endereco.Logradouro = leitor.GetString("logradouro_end");
                    endereco.Bairro = leitor.GetString("bairro_end");

                    var cidade = new Cidade();
                    cidade.Id = leitor.GetInt32("id_cid");
                    cidade.Nome = leitor.GetString("nome_cid");

                    var estado = new Estado();
                    estado.Id = leitor.GetInt32("id_est");
                    estado.Nome = leitor.GetString("nome_est");
                    estado.Sigla = leitor.GetString("sigla_est");

                    endereco.Cidade = cidade;
                    cidade.Estado = estado;

                    lista.Add(endereco);
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