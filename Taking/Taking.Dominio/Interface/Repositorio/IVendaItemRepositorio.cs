
using Taking.Dominio.Entidade;

namespace Taking.Dominio.Interface.Repositorio
{
    public interface IVendaItemRepositorio
    {
        int Add(VendaItemDominio obj);

        List<VendaItemDominio> ListaTodos(int vendaId);

        void CancelaItem(int VendaId, int vendaItemId);
    }
}
