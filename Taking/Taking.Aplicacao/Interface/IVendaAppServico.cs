using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Request;
using Taking.Dominio.Response;

namespace Taking.Aplicacao.Interface
{
    public interface IVendaAppServico
    {
        List<VendaResponse> BuscaPorData(DateTime dataInico, DateTime dataFim);

        VendaResponse BuscaPeloCodigo(string codVenda);

        int Add(VendaRequest obj);
    }
}
