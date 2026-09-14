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

                string sql = "SELECT * FROM venda";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var venda = new Venda();
                    venda.Id = leitor.GetInt32("id_vend");
                    venda.Data_Registro = leitor.GetDateTime("data_registro_vend");
                    venda.Descricao = leitor.GetString("descricao_vend");
                    venda.Cliente = leitor.GetString("id_cli_fk");
                    venda.Produto = leitor.GetString("id_pro_fk");
                    venda.Entregador = leitor.GetString("id_entr_fk");

                    lista.Add(venda);
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