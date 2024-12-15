using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Aplicacao.Interface
{
    public interface IProdutoAppServico : IListaTodos<ProdutoDominio>,
                                          IBuscaPorId<ProdutoDominio>,
                                          IAppServiceAdd<ProdutoDominio>,
                                          IAppServiceUpdate<ProdutoDominio>,
                                          IAppServiceRemove
    {
        ProdutoDominio BuscaPeloCodigo(string codProduto);
    }
}
