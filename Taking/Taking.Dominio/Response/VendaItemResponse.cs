
using System.Diagnostics.CodeAnalysis;
using Taking.Dominio.Entidade;

namespace Taking.Dominio.Response
{
    [ExcludeFromCodeCoverage]
    public class VendaItemResponse
    {
        public int VendaId { get; set; }

        public ProdutoDominio Produto { get; set; }

        public decimal QteProduto { get; set; }

        public decimal ValPrecoUnitario { get; set; }

        public decimal ValDescontoUnitario { get; set; }

        public string DescSituacao { get; set; }

        public decimal TotalDesconto
        {
            get
            {
                return this.QteProduto * this.ValDescontoUnitario;
            }
        }

        public decimal TotalSemDesconto
        {
            get
            {
                return this.QteProduto * this.ValPrecoUnitario;
            }
        }

        public decimal TotalComDesconto
        {
            get
            {
                return this.QteProduto * this.ValPrecoUnitario - this.TotalDesconto;
            }
        }
    }
}
