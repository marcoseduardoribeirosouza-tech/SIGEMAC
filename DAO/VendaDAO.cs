using SIGEMAC.Config;
using SIGEMAC.Model;

namespace SIGEMAC.DAO
{
    public class VendaDAO
    {

        private readonly Venda _venda;

        public VendaDAO(Venda venda)
        {
            _venda = venda;
        }


        public List<Venda> Listar()
        {
            try
            {
                var lista = new List<Venda>();
                using var con = _venda.GetConnection();

                string sql = "SELECT * FROM processos";
                using var comando = con.CreateCommand();
                comando.CommandText = sql;
                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var processo = new Processo();
                    processo.Id = leitor.GetInt32("id_vend");
                    processo.Data_Registro = leitor.GetString("data_registro_vend");
                    processo.Descricao = leitor.GetString("descricao_vend");
                    processo.Cliente = leitor.GetString("id_cli_fk");
                    processo.Produto = leitor.GetString("id_pro_fk");
                    processo.Entregador = leitor.GetString("id_entr_fk");

                    lista.Add(processo);
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