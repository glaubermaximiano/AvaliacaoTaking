using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Repositorio;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Dominio.Interface.Repositorio
{
    public interface IProdutoRepositorio : IListaTodos<ProdutoDominio>,
                                            IBuscaPorId<ProdutoDominio>,
                                            IAddRepositorio<ProdutoDominio>,
                                            IUpdateRepositorio<ProdutoDominio>,
                                            ICancelaRepositorio,
                                            IRemoveRepositorio
    {
        ProdutoDominio BuscaPeloCodigo(string codProduto);
    }
}
