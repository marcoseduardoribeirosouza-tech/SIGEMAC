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

            string sql = "SELECT * FROM registro inner join Cliente on (registro.id_cli_fk = cliente.id_cli) " +
                "inner join Venda on (registro.id_ven_fk = venda.id_ven) " +
                "inner join Entregador on (registro.id_entr_fk = entregador.id_entr)";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var registro = new Registro();
                registro.Id = leitor.GetInt32("id_reg");
                registro.Status = leitor.GetString("status_reg");

                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_forn");
                cliente.Nome = leitor.GetString("nome_forn");
                registro.Cliente = cliente;

                var venda = new Venda();
                venda.Id = leitor.GetInt32("id_forn");
                registro.Venda = venda;

                var entregador = new Entregador();
                entregador.Id = leitor.GetInt32("id_forn");
                entregador.Nome = leitor.GetString("nome_forn");
                registro.Entregador = entregador;
            }

            return lista;
        }
    }
}


