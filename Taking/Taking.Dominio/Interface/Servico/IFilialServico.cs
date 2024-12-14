using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Servico;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Dominio.Interface.Servico
{
    public interface IFilialServico : IListaTodos<FilialDominio>,
                                       IBuscaPorId<FilialDominio>,
                                       IAddServico<FilialDominio>,
                                       IUpdateServico<FilialDominio>,
                                       IRemoveServico
    {
    }
}
