using System.Diagnostics.CodeAnalysis;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseService
    {
        protected IUnitOfWork _repositorio;

        public BaseService(IUnitOfWork repositorio)
           => _repositorio = repositorio;
    }
}
