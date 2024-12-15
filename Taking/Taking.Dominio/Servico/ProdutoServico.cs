using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;

namespace Taking.Dominio.Servico
{
    [ExcludeFromCodeCoverage]
    public class ProdutoServico : BaseService, IProdutoServico
    {
        public ProdutoServico(IUnitOfWork repositorio)
            : base(repositorio) { }

        public List<ProdutoDominio> ListaTodos(string idcSituacao)
            => _repositorio.Produto.ListaTodos(idcSituacao);

        public ProdutoDominio BuscaPorId(int id)
            => _repositorio.Produto.BuscaPorId(id);

        public ProdutoDominio BuscaPeloCodigo(string codProduto)
            => _repositorio.Produto.BuscaPeloCodigo(codProduto);

        public string Add(ProdutoDominio obj)
        {
            try
            {
                _repositorio.Produto.Add(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public string Update(ProdutoDominio obj)
        {
            try
            {
                _repositorio.Produto.Update(obj);

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
                _repositorio.Produto.Remove(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
