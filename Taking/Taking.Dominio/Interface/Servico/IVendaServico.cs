using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Dominio.Interface.Servico
{
    public interface IVendaServico: IBuscaPorId<VendaDominio>
    {
        int Add(VendaDominio obj);

        List<VendaDominio> BuscaPorData(DateTime dthInicio, DateTime dthFim);

        List<VendaDominio> ListaPorCliente(int numCliente);

        List<VendaDominio> ListaPorFilial(int numFilial);

        VendaDominio BuscaPeloCodigo(int codVenda);

        string Cancela(int codVenda);
    }
}
