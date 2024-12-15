using Taking.Dominio.Entidade;

namespace Taking.Dominio.Interface.Servico
{
    public interface IVendaItemServico
    {
        int Add(VendaItemDominio obj);

        List<VendaItemDominio> ListaTodos(int vendaId);

        string CancelaItem(int VendaId, int vendaItemId);
    }
}
