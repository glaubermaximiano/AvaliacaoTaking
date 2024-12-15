using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Aplicacao.Interface;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;

namespace Taking.Aplicacao.Servico
{
    public class ClienteAppServico : Taking, IClienteAppServico
    {
        readonly IVendaServico _venda;
        readonly IClienteServico _servico;

        [ExcludeFromCodeCoverage]
        public ClienteAppServico(IVendaServico venda,
                                 IClienteServico servico)
        {
            _venda = venda;
            _servico = servico;
        }

        public List<ClienteDominio> ListaTodos(string idcSituacao)
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

        public ClienteDominio BuscaPorId(int id)
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

        public string Add(ClienteDominio obj)
        {
            try
            {
                if (_servico.ListaTodos("T").Any(x => x.NomCliente.ToLower() == obj.NomCliente.Trim().ToLower()))
                {
                    return "Já existe um Cliente cadastrado com este Nome!";
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

        public string Update(ClienteDominio obj)
        {
            try
            {
                var _objCliente = _servico.ListaTodos("T").Where(x => x.NomCliente.ToLower() == obj.NomCliente.Trim().ToLower()).FirstOrDefault();

                if ((_objCliente != null) && (_objCliente?.Id != obj.Id))
                {
                    return "Já existe um Cliente cadastrado com este Nome!";
                }

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
                if (_venda.ListaPorCliente(id).Any())
                {
                    return "Não é possível excluir Cliente que já possui Vendas!";
                }

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
    }
}
