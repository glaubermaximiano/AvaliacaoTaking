using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD;
using Taking.Dominio.Interface.CRUD.Servico;

namespace Taking.Dominio.Interface.Servico
{
    public interface IClienteServico : IListaTodos<ClienteDominio>,
                                       IBuscaPorId<ClienteDominio>,
                                       IAddServico<ClienteDominio>,
                                       IUpdateServico<ClienteDominio>,
                                       IRemoveServico
    {
    }
}
