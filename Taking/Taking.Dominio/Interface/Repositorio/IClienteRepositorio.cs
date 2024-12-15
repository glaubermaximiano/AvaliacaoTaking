using Taking.Dominio.Interface.CRUD.Repositorio;
using Taking.Dominio.Interface.CRUD;
using Taking.Dominio.Entidade;

namespace Taking.Dominio.Interface.Repositorio
{
    public interface IClienteRepositorio :  IListaTodos<ClienteDominio>,
                                            IBuscaPorId<ClienteDominio>,
                                            IAddRepositorio<ClienteDominio>,
                                            IUpdateRepositorio<ClienteDominio>,
                                            ICancelaRepositorio,
                                            IRemoveRepositorio
    {
    }
}
