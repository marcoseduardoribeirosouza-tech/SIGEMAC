using Org.BouncyCastle.Asn1;

namespace sigemac.Models
{
    public class Fornecedor
    {
        public int Id_forn { get; set; }
        public string nome_forn { get; set; } = string.Empty;
        public string cnpj_forn { get; set; } = string.Empty;
        public string telefone_forn { get; set; } = string.Empty;
        public string email_forn { get; set; } = string.Empty;

    }
}
