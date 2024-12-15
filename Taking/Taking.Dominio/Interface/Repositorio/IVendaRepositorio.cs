using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Repositorio;

namespace Taking.Dominio.Interface.Repositorio
{
    public interface IVendaRepositorio
    {
        int Add(VendaDominio obj);

        List<VendaDominio> BuscaPorData(DateTime dthInicio, DateTime dthFim);

        List<VendaDominio> ListaPorCliente(int numCliente);

        List<VendaDominio> ListaPorFilial(int numFilial);

        VendaDominio BuscaPeloCodigo(string codVenda);
    }
}
