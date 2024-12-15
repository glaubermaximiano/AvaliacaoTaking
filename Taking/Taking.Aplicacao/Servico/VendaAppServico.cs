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

        [ExcludeFromCodeCoverage]
        public VendaAppServico( IClienteServico cliente,
                                IFilialServico filial,
                                IVendaServico servico)
        {
            _cliente = cliente;
            _filial = filial;
            _servico = servico;
        }

        VendaResponse GetVenda(VendaDominio obj)
        {
            return new VendaResponse()
            {
                CodVenda = obj.CodVenda,
                DthVenda = obj.DthVenda,
                DescSituacao = obj.DescSituacao,
                Cliente = _cliente.BuscaPorId(obj.NumCliente),
                Filial = _filial.BuscaPorId(obj.NumFilial)
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

        public VendaResponse BuscaPeloCodigo(string codVenda)
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
                var _objCliente = _cliente.BuscaPorId(obj.NumCliente);

                if (_objCliente == null)
                {
                    new TakingException("Cliente nao encontrado!");
                }

                if (_objCliente.IdcSituacao == "I")
                {
                    new TakingException("Cliente informado esta Inativo!");
                }

                var _objFilial = _filial.BuscaPorId(obj.NumCliente);

                if (_objFilial == null)
                {
                    new TakingException("Filial nao encontrado!");
                }

                if (_objFilial.IdcSituacao == "I")
                {
                    new TakingException("Filial informada esta Inativa!");
                }

                var _codVenda = _servico.Add(new VendaDominio() {
                                                                    DthVenda = obj.DthVenda,
                                                                    NumCliente = obj.NumCliente,
                                                                    NumFilial = obj.NumFilial,
                                                                    IdcSituacao = "A"
                                                                });

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
    }
}
