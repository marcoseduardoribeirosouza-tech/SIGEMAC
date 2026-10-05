using sigemac.Configs;
using sigemac.Models;

namespace sigemac.DAO
{
    public class RegistroDAO
    {
        private readonly Conexao _conexao;
        public RegistroDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Registro> Listar()
        {
            var lista = new List<Registro>();

            using var con = _conexao.GetConnection();

            string sql = "SELECT * FROM registro left join Cliente on (registro.id_cli_fk = cliente.id_cli) " +
                "left join Venda on (registro.id_vend_fk = venda.id_vend) " +
                "left join Entregador on (registro.id_entr_fk = entregador.id_entr)" +
                "left join Produto on (registro.id_pro_fk = produto.id_pro)" +
                "left join Fornecedor on (registro.id_forn_fk = fornecedor.id_forn)";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var registro = new Registro();
                registro.Id = leitor.GetInt32("id_reg");
                registro.Status = leitor.GetString("status_reg");

                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cli");
                cliente.Nome = leitor.GetString("nome_cli");
                cliente.Cpf = leitor.GetString("cpf_cli");
                cliente.Email = leitor.GetString("email_cli");
                cliente.Telefone = leitor.GetString("telefone_cli");
                registro.Cliente = cliente;

                var entregador = new Entregador();
                entregador.Nome = leitor.GetString("nome_entr");
                entregador.Telefone = leitor.GetString("telefone_entr");
                entregador.CNH = leitor.GetString("cnh_entr");
                entregador.Descricao = leitor.GetString("descricao_entr");
                entregador.DataNascimento = leitor.GetDateTime("data_nasc_entr");
                entregador.DataCadastro = leitor.GetDateTime("data_cadastro_entr");
                registro.Entregador = entregador;

                var produto = new Produto();
                produto.Id = leitor.GetInt32("id_pro");
                produto.Nome = leitor.GetString("nome_pro");
                produto.Quantidade = leitor.GetInt32("quantidade_pro");
                produto.Preco = leitor.GetDecimal("preco_pro");
                produto.Descricao = leitor.GetString("descricao_pro");
                registro.Produto = produto;

                var fornecedor = new Fornecedor();
                fornecedor.Id = leitor.GetInt32("id_forn");
                fornecedor.Nome = leitor.GetString("nome_forn");
                fornecedor.Cnpj = leitor.GetString("cnpj_forn");
                fornecedor.Telefone = leitor.GetString("telefone_forn");
                fornecedor.Email = leitor.GetString("email_forn");
                registro.Fornecedor = fornecedor;
                produto.Fornecedor = fornecedor;

                var venda = new Venda();
                venda.Id = leitor.GetInt32("id_vend");
                venda.DataRegistro = DateOnly.FromDateTime(leitor.GetDateTime("data_registro_vend"));
                venda.Descricao = leitor.GetString("descricao_vend");
                registro.Venda = venda;
                registro.Venda.Cliente = cliente;
                registro.Venda.Produto = produto;
                registro.Venda.Entregador = entregador;

                lista.Add(registro);
            }

            return lista;
        }
    }
}


