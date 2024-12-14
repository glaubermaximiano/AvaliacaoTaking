using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Aplicacao.Interface;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Servico;

namespace Taking.Aplicacao.Servico
{
    public class FilialAppServico : Taking, IFilialAppServico
    {
        readonly IFilialServico _servico;

        [ExcludeFromCodeCoverage]
        public FilialAppServico(IFilialServico servico)
        {
            _servico = servico;
        }

        public List<FilialDominio> ListaTodos(string idcSituacao)
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

        public FilialDominio BuscaPorId(int id)
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

        public string Add(FilialDominio obj)
        {
            try
            {
                if (_servico.ListaTodos("T").Any(x => x.NomFilial.ToLower() == obj.NomFilial.Trim().ToLower()))
                {
                    return "Já existe uma Filial cadastrada com este Nome!";
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

        public string Update(FilialDominio obj)
        {
            try
            {
                var _objCliente = _servico.ListaTodos("T").Where(x => x.NomFilial.ToLower() == obj.NomFilial.Trim().ToLower()).FirstOrDefault();

                if ((_objCliente != null) && (_objCliente?.Id != obj.Id))
                {
                    return "Já existe uma Filial cadastrada com este Nome!";
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
