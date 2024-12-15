using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Infra.Dados.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class VendaRepositorio : ConexaoDB, IVendaRepositorio
    {
        public VendaRepositorio(string strConexao)
            : base(strConexao) { }

        string _qry = @" SELECT num_venda as Id,
                                cod_venda as CodVenda,
                                dth_venda as DthVenda,
                                num_cliente as ClienteId,
                                num_filial as FilialId,
                                idc_situacao as IdcSituacao
                         FROM venda ";

        int GeraNumeroVenda()
        {
            var _sql = @" SELECT COALESCE(MAX(cod_venda), CAST(CAST(RIGHT(CAST(EXTRACT(YEAR FROM NOW()) as CHAR(4)) , 2) as CHAR(2)) || '0000000' AS INTEGER))+ 1 as CodigoVenda
                          FROM venda
                          WHERE EXTRACT(YEAR FROM dth_venda) = EXTRACT(YEAR FROM NOW()) ";

            return int.Parse(this.Execute(_sql).ToString());
        }

        public List<VendaDominio> BuscaPorData(DateTime dthInicio, DateTime dthFim)
        {
            try
            {
                var _novaQuery = $"{_qry} WHERE  dth_venda BETWEEN '{dthInicio.ToString("yyyy-MM-dd")}' AND '{dthFim.ToString("yyyy-MM-dd")} 23:59:59'";

                return this.Query<VendaDominio>(_novaQuery).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public List<VendaDominio> ListaPorCliente(int numCliente)
        {
            try
            {
                var _filtro = $" WHERE num_cliente = {numCliente}";

                return this.Query<VendaDominio>($"{_qry} {_filtro}").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public List<VendaDominio> ListaPorFilial(int numFilial)
        {
            try
            {
                var _filtro = $" WHERE num_filial = {numFilial}";

                return this.Query<VendaDominio>($"{_qry} {_filtro}").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public VendaDominio BuscaPeloCodigo(int codVenda)
        {
            try
            {
                return QueryFirstOrDefault<VendaDominio>($"{_qry} WHERE cod_venda = '{codVenda}'");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public VendaDominio BuscaPorId(int id)
        {
            try
            {
                return QueryFirstOrDefault<VendaDominio>($"{_qry} WHERE num_venda = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public int Add(VendaDominio obj)
        {
            try
            {
                var _codVenda = GeraNumeroVenda();

                var _query = @$" INSERT INTO venda (cod_venda, dth_venda, num_cliente, num_filial, idc_situacao)
								 VALUES ('{_codVenda}', '{obj.DthVenda.ToString("yyyy-MM-dd HH:mm")}', {obj.ClienteId}, {obj.FilialId}, '{obj.IdcSituacao}')";

                Execute(_query);

                return _codVenda;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Cancela(int codVenda)
        {
            try
            {
                var _query = @$" UPDATE venda 
                                 SET idc_situacao = 'I'
								 WHERE cod_venda = '{codVenda}'";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
