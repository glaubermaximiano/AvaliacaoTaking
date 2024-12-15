using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class ClienteServico : BaseService, IClienteServico
    {
        public ClienteServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<ClienteDominio> ListaTodos(string idcSituacao)
            => _repositorio.Cliente.ListaTodos(idcSituacao);

        public ClienteDominio BuscaPorId(int id)
           => _repositorio.Cliente.BuscaPorId(id);

        public string Add(ClienteDominio obj)
        {
            try
            {
                _repositorio.Cliente.Add(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Update(ClienteDominio obj)
        {
            try
            {
                _repositorio.Cliente.Update(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Remove(int id)
        {
            try
            {
                _repositorio.Cliente.Remove(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Cancela(int id)
        {
            try
            {
                _repositorio.Cliente.Cancela(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
