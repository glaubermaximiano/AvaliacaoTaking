using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class VendaItemServico : BaseService, IVendaItemServico
    {
        public VendaItemServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<VendaItemDominio> ListaTodos(int vendaId)
           => _repositorio.VendaItem.ListaTodos(vendaId);

        public int Add(VendaItemDominio obj)
        {
            try
            {
                return _repositorio.VendaItem.Add(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string CancelaItem(int VendaId, int vendaItemId)
        {
            try
            {
                _repositorio.VendaItem.CancelaItem(VendaId, vendaItemId);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
