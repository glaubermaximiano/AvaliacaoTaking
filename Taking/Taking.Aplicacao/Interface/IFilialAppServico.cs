using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Aplicacao.Interface
{
    public interface IFilialAppServico : IListaTodos<FilialDominio>,
                                            IBuscaPorId<FilialDominio>,
                                            IAppServiceAdd<FilialDominio>,
                                            IAppServiceUpdate<FilialDominio>,
                                            IAppServiceRemove
    {
    }
}
