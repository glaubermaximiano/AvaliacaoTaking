using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Aplicacao.Interface;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;

namespace Taking.Aplicacao.Servico
{
    public class ProdutoAppServico : Taking, IProdutoAppServico
    {
        readonly IProdutoServico _servico;

        [ExcludeFromCodeCoverage]
        public ProdutoAppServico(IProdutoServico servico)
        {
            _servico = servico;
        }

        public List<ProdutoDominio> ListaTodos(string idcSituacao)
        {
            try
            {
                return _servico.ListaTodos(idcSituacao);
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public ProdutoDominio BuscaPorId(int id)
        {
            try
            {
                return _servico.BuscaPorId(id);
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public ProdutoDominio BuscaPeloCodigo(string codProduto)
        {
            try
            {
                return _servico.BuscaPeloCodigo(codProduto);
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string Add(ProdutoDominio obj)
        {
            try
            {
                if (this.BuscaPeloCodigo(obj.CodProduto) != null)
                {
                    return "Já existe uma Produto cadastrad com este Código!";
                }

                _servico.Add(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string Update(ProdutoDominio obj)
        {
            try
            {
                _servico.Update(obj);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string Remove(int id)
        {
            try
            {
                _servico.Remove(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string Cancela(int id)
        {
            try
            {
                var _objProduto = _servico.BuscaPorId(id);

                if (_objProduto == null)
                {
                    return "Produto não encontrado!";
                }

                if (_objProduto.IdcSituacao == "I")
                {
                    return "Produto já cancelado!";
                }

                _servico.Cancela(id);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }
    }
}
