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
    public class VendaAppServico : Taking, IVendaAppServico
    {
        readonly IClienteServico _cliente;
        readonly IFilialServico _filial;
        readonly IVendaServico _servico;
        readonly IVendaItemAppServico _vendaItem;

        [ExcludeFromCodeCoverage]
        public VendaAppServico( IClienteServico cliente,
                                IFilialServico filial,
                                IVendaServico servico,
                                IVendaItemAppServico vendaItem)
        {
            _cliente = cliente;
            _filial = filial;
            _servico = servico;
            _vendaItem = vendaItem;
        }

        VendaResponse GetVenda(VendaDominio obj)
        {
            var _items = _vendaItem.ListaTodos( _servico.BuscaPeloCodigo(obj.CodVenda).Id );

            return new VendaResponse()
            {
                Id = obj.Id,
                CodVenda = obj.CodVenda,
                DthVenda = obj.DthVenda,
                DescSituacao = obj.DescSituacao,
                Cliente = _cliente.BuscaPorId(obj.ClienteId),
                Filial = _filial.BuscaPorId(obj.FilialId),
                VlrDesconto = _items.Sum(x => x.TotalDesconto),
                VlrSemDesconto = _items.Sum(x => x.TotalSemDesconto),
                VlrComDesconto = _items.Sum(x => x.TotalComDesconto),

                Items = _items
            };
        }

        public List<VendaResponse> BuscaPorData(DateTime dataInico, DateTime dataFim)
        {
            try
            {
                return (from v in _servico.BuscaPorData(dataInico, dataFim)
                        select this.GetVenda(v)).ToList();
            }
            catch (Exception ex) 
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public VendaResponse BuscaPeloCodigo(int codVenda)
        {
            try
            {
                return this.GetVenda(_servico.BuscaPeloCodigo(codVenda));
            }
            catch (Exception ex)
            {
                var msgErro = "ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message;

                TrataErro(msgErro);

                throw new Exception(msgErro);
            }
        }

        public int Add(VendaRequest obj)
        {
            try
            {
                var _objCliente = _cliente.BuscaPorId(obj.ClienteId);

                if (_objCliente == null)
                {
                    throw new TakingException("Cliente nao encontrado!");
                }

                if (_objCliente.IdcSituacao == "I")
                {
                    throw new TakingException("Cliente informado esta cancelado!");
                }

                var _objFilial = _filial.BuscaPorId(obj.ClienteId);

                if (_objFilial == null)
                {
                    throw new TakingException("Filial nao encontrado!");
                }

                if (_objFilial.IdcSituacao == "I")
                {
                    throw new TakingException("Filial informada esta cancelado!");
                }

                if (obj.Items.Count() == 0)
                {
                    throw new TakingException("Venda não possui Items!");
                }

                var _lstProdutosDuplicados = obj.Items
                                            .GroupBy(p => new { p.CodProduto})
                                            .Where(g => g.Count() > 1)
                                            .ToList();

                if (_lstProdutosDuplicados.Count() != 0)
                {
                    throw new TakingException("Existem Produtos duplicados na lista!");
                }

                foreach (var item in obj.Items)
                {
                    var _msgValida = _vendaItem.ValidaItemVenda(item);

                    if (!string.IsNullOrEmpty(_msgValida))
                    {
                        throw new TakingException(_msgValida);
                    }
                }

                var _codVenda = _servico.Add(new VendaDominio() {
                                                                    DthVenda = obj.DthVenda,
                                                                    ClienteId = obj.ClienteId,
                                                                    FilialId = obj.FilialId,
                                                                    IdcSituacao = "A"
                                                                });

                foreach (var item in obj.Items)
                {
                    var _msgValida = _vendaItem.ValidaItemVenda(item);

                    if (!string.IsNullOrEmpty(_msgValida))
                    {
                        new TakingException(_msgValida);
                    }

                    _vendaItem.Add(_codVenda, item);
                }

                return _codVenda;
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

        public string Cancela(int codVenda)
        {
            try
            {
                var _objProduto = _servico.BuscaPeloCodigo(codVenda);

                if (_objProduto == null)
                {
                    return "Venda não encontrada!";
                }

                if (_objProduto.IdcSituacao == "I")
                {
                    return "Venda já cancelada!";
                }

                _servico.Cancela(codVenda);

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
