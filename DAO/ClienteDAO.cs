using System.Linq.Expressions;
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

                string sql = @"
            SELECT 
                cliente.*,
                endereco.id_end,
                endereco.numero_end,
                endereco.logradouro_end,
                endereco.bairro_end,
                cidade.id_cid,
                cidade.nome_cid,
                estado.id_est,
                estado.nome_est,
                estado.sigla_est
            FROM cliente
            LEFT JOIN endereco 
                ON cliente.id_end_fk = endereco.id_end
            LEFT JOIN cidade 
                ON endereco.id_cid_fk = cidade.id_cid
            LEFT JOIN estado 
                ON cidade.id_est_fk = estado.id_est;
        ";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = leitor.GetInt32("id_cli");
                    cliente.Nome = leitor.GetString("nome_cli");
                    cliente.Email = leitor.GetString("email_cli");
                    cliente.Telefone = leitor.GetString("telefone_cli");
                    cliente.Observacao = leitor.GetString("observacao_cli");
                    cliente.Cpf = leitor.GetString("cpf_cli");

                    // Verifica se o cliente possui endereço
                    if (!leitor.IsDBNull(leitor.GetOrdinal("id_end")))
                    {
                        var endereco = new Endereco();

                        endereco.Id = leitor.GetInt32("id_end");
                        endereco.Numero = leitor.GetInt32("numero_end");
                        endereco.Logradouro = leitor.GetString("logradouro_end");
                        endereco.Bairro = leitor.GetString("bairro_end");

                        // Verifica se existe cidade
                        if (!leitor.IsDBNull(leitor.GetOrdinal("id_cid")))
                        {
                            var cidade = new Cidade();

                            cidade.Id = leitor.GetInt32("id_cid");
                            cidade.Nome = leitor.GetString("nome_cid");

                            // Verifica se existe estado
                            if (!leitor.IsDBNull(leitor.GetOrdinal("id_est")))
                            {
                                var estado = new Estado();

                                estado.Id = leitor.GetInt32("id_est");
                                estado.Nome = leitor.GetString("nome_est");
                                estado.Sigla = leitor.GetString("sigla_est");

                                cidade.Estado = estado;
                            }

                            endereco.Cidade = cidade;
                        }

                        cliente.Endereco = endereco;
                    }

                    lista.Add(cliente);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }


        public void Inserir(Cliente cliente)
        {
            try
            {
                using var con = _conexao.GetConnection();
                string sql = "INSERT INTO cliente (nome_cli, email_cli, telefone_cli, observacao_cli, cpf_cli, id_end_fk) VALUES (@nome, @email, @telefone, @observacao, @cpf, @id_end);";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@observacao", cliente.Observacao);
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);

                if (cliente.Endereco != null)
                {
                    comando.Parameters.AddWithValue("@id_end", cliente.Endereco.Id);
                }
                else
                {
                    comando.Parameters.AddWithValue("@id_end", DBNull.Value);
                }

                comando.ExecuteNonQuery();
            } catch
            {
                throw;
            }
        }
    }
}