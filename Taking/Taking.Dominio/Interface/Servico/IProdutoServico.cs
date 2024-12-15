using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.CRUD.Servico;
using Taking.Dominio.Interface.CRUD;

namespace Taking.Dominio.Interface.Servico
{
    public interface IProdutoServico :  IListaTodos<ProdutoDominio>,
                                        IBuscaPorId<ProdutoDominio>,
                                        IAddServico<ProdutoDominio>,
                                        IUpdateServico<ProdutoDominio>,
                                        ICancelaServico,
                                        IRemoveServico
    {
        ProdutoDominio BuscaPeloCodigo(string codProduto);
    }
}
