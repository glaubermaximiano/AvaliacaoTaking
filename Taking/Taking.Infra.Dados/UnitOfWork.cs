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
    }
}
