using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Aplicacao.Interface
{
    public interface IClienteAppServico :   IListaTodos<ClienteDominio>,
                                            IBuscaPorId<ClienteDominio>,
                                            IAppServiceAdd<ClienteDominio>,
                                            IAppServiceUpdate<ClienteDominio>,
                                            ICancelaAppServico,
                                            IAppServiceRemove
    {
    }
}
