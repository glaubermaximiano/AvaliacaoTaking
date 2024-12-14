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
    }
}
