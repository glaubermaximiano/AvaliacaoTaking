using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Request
{
    [ExcludeFromCodeCoverage]
    public class VendaItemRequest
    {
        public string CodProduto { get; set; }

        public decimal QteProduto { get; set; }

        public decimal ValDescontoUnitario { get; set; }
    }
}
