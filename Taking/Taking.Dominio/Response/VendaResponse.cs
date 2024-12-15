using System.Diagnostics.CodeAnalysis;
using Taking.Dominio.Entidade;

namespace Taking.Dominio.Response
{
    [ExcludeFromCodeCoverage]
    public class VendaResponse
    {
        public VendaResponse()
            => this.Items = new List<VendaItemResponse>();
        public int Id { get; set; }

        public DateTime DthVenda { get; set; }

        public int CodVenda { get; set; }

        public ClienteDominio Cliente { get; set; }

        public FilialDominio Filial { get; set; }

        public string DescSituacao { get; set; }

        public decimal VlrDesconto { get; set; }

        public decimal VlrSemDesconto { get; set; }

        public decimal VlrComDesconto { get; set; }

        public List<VendaItemResponse> Items { get; set; }
    }
}
