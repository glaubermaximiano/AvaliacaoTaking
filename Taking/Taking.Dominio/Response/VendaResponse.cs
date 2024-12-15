using Taking.Dominio.Entidade;

namespace Taking.Dominio.Response
{
    public class VendaResponse
    {
        public DateTime DthVenda { get; set; }

        public string CodVenda { get; set; }

        public ClienteDominio Cliente { get; set; }

        public FilialDominio Filial { get; set; }

        public string DescSituacao { get; set; }
    }
}
