using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio.Entidade
{
    [ExcludeFromCodeCoverage]
    public class VendaItemDominio : BaseEntidade
    {
        public int VendaId { get; set; }

        public int ProdutoId { get; set; }

        public decimal QteProduto { get; set; }

        public decimal ValPrecoUnitario { get; set; }

        public decimal ValDescontoUnitario { get; set; }
    }
}
