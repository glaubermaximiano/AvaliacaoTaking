using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Request;
using Taking.Dominio.Response;

namespace Taking.Aplicacao.Interface
{
    public interface IVendaAppServico: ICancelaAppServico
    {
        List<VendaResponse> BuscaPorData(DateTime dataInico, DateTime dataFim);

        VendaResponse BuscaPeloCodigo(int codVenda);

        int Add(VendaRequest obj);
    }
}
