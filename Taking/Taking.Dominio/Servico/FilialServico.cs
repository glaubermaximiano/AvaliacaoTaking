using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class FilialServico : BaseService, IFilialServico
    {
        public FilialServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<FilialDominio> ListaTodos(string idcSituacao)
            => _repositorio.Filial.ListaTodos(idcSituacao);

        public FilialDominio BuscaPorId(int id)
           => _repositorio.Filial.BuscaPorId(id);

        public string Add(FilialDominio obj)
        {
            try
            {
                _repositorio.Filial.Add(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Update(FilialDominio obj)
        {
            try
            {
                _repositorio.Filial.Update(obj);

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
                _repositorio.Filial.Remove(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
