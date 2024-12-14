using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Infra.Dados.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class FilialRepositorio : ConexaoDB, IFilialRepositorio
    {
        public FilialRepositorio(string strConexao)
            : base(strConexao) { }

        string _qry = @" SELECT num_filial as Id,
                                nom_filial as NomFilial,
                                idc_situacao as IdcSituacao
                         FROM filial ";

        public List<FilialDominio> ListaTodos(string idcSituacao)
        {
            try
            {
                var _filtro = string.Empty;

                if (idcSituacao != "T")
                {
                    _filtro = $" WHERE idc_situacao = '{idcSituacao}'";
                }

                return this.Query<FilialDominio>($"{_qry} {_filtro}").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public FilialDominio BuscaPorId(int id)
        {
            try
            {
                return QueryFirstOrDefault<FilialDominio>($"{_qry} WHERE num_filial = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Add(FilialDominio obj)
        {
            try
            {
                var _query = @$" INSERT INTO filial (nom_filial, idc_situacao)
								 VALUES ('{obj.NomFilial.Trim()}', '{obj.IdcSituacao.Trim()}')";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Update(FilialDominio obj)
        {
            try
            {
                var _query = @$" UPDATE filial 
                                 SET nom_filial = '{obj.NomFilial.Trim()}', 
                                     idc_situacao = '{obj.IdcSituacao.Trim()}'
                                 WHERE num_filial= {obj.Id} ";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                var _query = @$" DELETE FROM filial 
                                 WHERE num_filial= {id} ";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
