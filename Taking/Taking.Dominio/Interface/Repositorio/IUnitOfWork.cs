
namespace Taking.Dominio.Interface.Repositorio
{
    public interface IUnitOfWork
    {
        string StrConexao { set; get; }

        IClienteRepositorio Cliente { get; }

        IFilialRepositorio Filial { get; }

        IProdutoRepositorio Produto { get; }

        IVendaRepositorio Venda { get; }

        IVendaItemRepositorio VendaItem { get; }
    }
}
