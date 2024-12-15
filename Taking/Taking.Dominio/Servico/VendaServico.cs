using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class VendaServico : BaseService, IVendaServico
    {
        public VendaServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<VendaDominio> BuscaPorData(DateTime dthInicio, DateTime dthFim)
            => _repositorio.Venda.BuscaPorData(dthInicio, dthFim);

        public List<VendaDominio> ListaPorCliente(int numCliente)
           => _repositorio.Venda.ListaPorCliente(numCliente);

        public List<VendaDominio> ListaPorFilial(int numFilial)
           => _repositorio.Venda.ListaPorFilial(numFilial);

        public VendaDominio BuscaPeloCodigo(int codVenda)
           => _repositorio.Venda.BuscaPeloCodigo(codVenda);

        public VendaDominio BuscaPorId(int id)
           => _repositorio.Venda.BuscaPorId(id);

        public int Add(VendaDominio obj)
        {
            try
            {
                return _repositorio.Venda.Add(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Cancela(int codVenda)
        {
            try
            {
                _repositorio.Venda.Cancela(codVenda);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
