using Taking.Dominio.Entidade;
using Taking.Dominio.Request;
using Taking.Dominio.Response;

namespace Taking.Aplicacao.Interface
{
    public interface IVendaItemAppServico
    {
        int Add(int codVenda, VendaItemRequest obj);

        List<VendaItemResponse> ListaTodos(int vendaId);

        string ValidaItemVenda(VendaItemRequest obj);

        string CancelaItem(int vendaId, int vendaItemId);
    }
}
