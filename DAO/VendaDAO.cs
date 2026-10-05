using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class VendaDAO
    {

        private readonly Conexao _conexao;

        public VendaDAO(Conexao conexao)
        {
            _conexao = conexao;
        }


        public List<Venda> Listar()
        {
            try
            {
                var lista = new List<Venda>();
                using var con = _conexao.GetConnection();

                string sql = "SELECT * FROM venda LEFT JOIN Cliente ON (id_cli_fk = id_cli) LEFT JOIN produto ON (id_pro_fk = id_pro) LEFT JOIN entregador ON (id_entr_fk = id_entr) LEFT JOIN endereco ON (id_end_fk = id_end) " +
                    "LEFT JOIN cidade ON (id_cid_fk = id_cid) LEFT JOIN estado ON (id_est_fk = id_est) left join fornecedor on (id_forn_fk = id_forn);";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var venda = new Venda();
                    venda.Id = leitor.GetInt32("id_vend");
                    venda.DataRegistro = DateOnly.FromDateTime(leitor.GetDateTime("data_registro_vend"));
                    venda.Descricao = leitor.GetString("descricao_vend");

                    #region cliente
                    var cliente = new Cliente();
                    cliente.Id = leitor.GetInt32("id_cli");
                    cliente.Nome = leitor.GetString("nome_cli");
                    cliente.Email = leitor.GetString("email_cli");
                    cliente.Telefone = leitor.GetString("telefone_cli");
                    cliente.Observacao = leitor.GetString("observacao_cli");
                    cliente.Cpf = leitor.GetString("cpf_cli");

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
                    cliente.Endereco = endereco;
                    endereco.Cidade = cidade;
                    cidade.Estado = estado;
                    
                    venda.Cliente = cliente;
                    #endregion cliente

                    #region produto
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
                    venda.Produto = produto;
                    #endregion produto

                    #region entregador
                    var entregador = new Entregador();
                    entregador.Id = leitor.GetInt32("id_entr");
                    entregador.Nome = leitor.GetString("nome_entr");
                    entregador.Telefone = leitor.GetString("telefone_entr");
                    entregador.CNH = leitor.GetString("cnh_entr");
                    entregador.Descricao = leitor.GetString("descricao_entr");
                    entregador.DataNascimento = leitor.GetDateTime("data_nasc_entr");
                    entregador.DataCadastro = leitor.GetDateTime("data_cadastro_entr");
                    venda.Entregador = entregador;
                    #endregion entregador

                    lista.Add(venda);
                }
                
                return lista;
            }
            catch
            {
                throw;
            }
        }
        public void Inserir(Venda venda)
        {
            try
            {
                using var con = _conexao.GetConnection();
                string sql = @"INSERT INTO venda
                (id_vend, data_registro_vend, descricao_vend,id_cli_fk, id_pro_fk, id_entr_fk)
                VALUES
                (@id, @dataRegistro, @descricao, @cliente, @produto, @entregador)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                comando.Parameters.AddWithValue("@id", venda.Id);
                comando.Parameters.AddWithValue("@dataRegistro", venda.DataRegistro!.Value.ToDateTime(TimeOnly.MinValue));
                comando.Parameters.AddWithValue("@descricao", venda.Descricao);
                comando.Parameters.AddWithValue("@cliente", venda.Cliente.Id);
                comando.Parameters.AddWithValue("@produto", venda.Produto.Id);
                comando.Parameters.AddWithValue("@entregador", venda.Entregador.Id);

                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

    }
}