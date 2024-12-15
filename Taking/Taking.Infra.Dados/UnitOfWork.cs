using System.Diagnostics.CodeAnalysis;
using Taking.Dominio.Interface.Repositorio;
using Taking.Infra.Dados.Repositorio;

namespace Taking.Infra.Dados
{
    [ExcludeFromCodeCoverage]
    public class UnitOfWork : IUnitOfWork
    {
        public string StrConexao { set; get; }

        IClienteRepositorio _cliente;
        public IClienteRepositorio Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new ClienteRepositorio(this.StrConexao);
                }

                return _cliente;
            }
        }

        IFilialRepositorio _filial;
        public IFilialRepositorio Filial
        {
            get
            {
                if (_filial == null)
                {
                    _filial = new FilialRepositorio(this.StrConexao);
                }

                return _filial;
            }
        }

        IProdutoRepositorio _produto;
        public IProdutoRepositorio Produto
        {
            get
            {
                if (_produto == null)
                {
                    _produto = new ProdutoRepositorio(this.StrConexao);
                }

                return _produto;
            }
        }

        IVendaRepositorio _venda;
        public IVendaRepositorio Venda
        {
            get
            {
                if (_venda == null)
                {
                    _venda = new VendaRepositorio(this.StrConexao);
                }

                return _venda;
            }
        }

        IVendaItemRepositorio _vendaItem;
        public IVendaItemRepositorio VendaItem
        {
            get
            {
                if (_vendaItem == null)
                {
                    _vendaItem = new VendaItemRepositorio(this.StrConexao);
                }

                return _vendaItem;
            }
        }
    }
}
