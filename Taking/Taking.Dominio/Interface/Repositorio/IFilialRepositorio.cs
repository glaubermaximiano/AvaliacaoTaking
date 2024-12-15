using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Repositorio;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Dominio.Interface.Repositorio
{
    public interface IFilialRepositorio :   IListaTodos<FilialDominio>,
                                            IBuscaPorId<FilialDominio>,
                                            IAddRepositorio<FilialDominio>,
                                            IUpdateRepositorio<FilialDominio>,
                                            ICancelaRepositorio,
                                            IRemoveRepositorio
    {
    }
}
