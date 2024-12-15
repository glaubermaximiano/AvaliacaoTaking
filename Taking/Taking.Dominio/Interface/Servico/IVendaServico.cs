using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Servico;

namespace Taking.Dominio.Interface.Servico
{
    public interface IVendaServico 
    {
        int Add(VendaDominio obj);

        List<VendaDominio> BuscaPorData(DateTime dthInicio, DateTime dthFim);

        List<VendaDominio> ListaPorCliente(int numCliente);

        List<VendaDominio> ListaPorFilial(int numFilial);

        VendaDominio BuscaPeloCodigo(string codVenda);
    }
}
