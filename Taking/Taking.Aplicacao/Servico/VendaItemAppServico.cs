using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Aplicacao.Interface;
using Taking.Dominio;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;
using Taking.Dominio.Request;
using Taking.Dominio.Response;

namespace Taking.Aplicacao.Servico
{
    public class VendaItemAppServico : Taking, IVendaItemAppServico
    {
        readonly IVendaServico _venda;
        readonly IProdutoServico _produto;
        readonly IVendaItemServico _servico;

        [ExcludeFromCodeCoverage]
        public VendaItemAppServico(IVendaServico venda,
                                IProdutoServico produto,
                                IVendaItemServico servico)
        {
            _venda = venda;
            _produto = produto;
            _servico = servico;
        }

        VendaItemResponse GetItem(VendaItemDominio obj)
        {
            return new VendaItemResponse()
            {
                VendaId = obj.VendaId,
                Produto = _produto.BuscaPorId(obj.ProdutoId),
                QteProduto = obj.QteProduto,
                ValPrecoUnitario = obj.ValPrecoUnitario,
                ValDescontoUnitario = obj.ValDescontoUnitario,
                DescSituacao = obj.DescSituacao
            };
        }

        public List<VendaItemResponse> ListaTodos(int vendaId)
        {
            try
            {
                return (from v in _servico.ListaTodos(vendaId)
                        select this.GetItem(v)).ToList();
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public int Add(int codVenda, VendaItemRequest obj)
        {
            try
            {
                var _objVenda = _venda.BuscaPeloCodigo(codVenda);

                if (_objVenda == null)
                {
                    throw new TakingException("Venda nao encontrada!");
                }

                if (_objVenda.IdcSituacao == "I")
                {
                    throw new TakingException("Venda informado está cancelada!");
                }

                var _msg = this.ValidaItemVenda(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    throw new TakingException(_msg);
                }

                var _objProduto = _produto.BuscaPeloCodigo(obj.CodProduto);

                var _codVendaItem = _servico.Add(new VendaItemDominio()
                {
                    VendaId = _objVenda.Id,
                    ProdutoId = _objProduto.Id,
                    QteProduto = obj.QteProduto,
                    ValPrecoUnitario = _objProduto.ValPrecoUnitario,
                    ValDescontoUnitario = obj.ValDescontoUnitario,
                    IdcSituacao = "A"
                });

                return _codVendaItem;
            }
            catch (TakingException ex)
            {
                throw new TakingException(ex.Message);
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string CancelaItem(int vendaId, int vendaItemId)
        {
            try
            {
                var _objVendaItem = _servico.ListaTodos(vendaId).Where(x => x.Id == vendaItemId).FirstOrDefault();

                if (_objVendaItem == null)
                {
                    return "Item não encontrada!";
                }

                if (_objVendaItem.IdcSituacao == "I")
                {
                    return "Item já cancelado!";
                }

                _servico.CancelaItem(vendaId, vendaItemId);

                return string.Empty;
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public string ValidaItemVenda(VendaItemRequest obj)
        {
            try
            {
                var _objProduto = _produto.BuscaPeloCodigo(obj.CodProduto);

                if (_objProduto == null)
                {
                    return "Produto nao encontrado!";
                }

                if (_objProduto.IdcSituacao == "I")
                {
                    return "Produto informada esta cancelado!";
                }

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
