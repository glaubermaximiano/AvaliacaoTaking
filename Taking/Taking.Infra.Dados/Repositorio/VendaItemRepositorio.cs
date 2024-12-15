using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Infra.Dados.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class VendaItemRepositorio : ConexaoDB, IVendaItemRepositorio
    {
        public VendaItemRepositorio(string strConexao)
            : base(strConexao) { }

        string _qry = @" SELECT num_venda as VendaId,
                                num_venda_item as Id,
                                num_produto as ProdutoId,
                                qte_produto as QteProduto,
                                val_preco_unitario as ValPrecoUnitario,
                                val_desconto_unitario as ValDescontoUnitario,
                                idc_situacao as IdcSituacao
                         FROM venda_item ";

        public List<VendaItemDominio> ListaTodos(int vendaId)
        {
            try
            {
                var _novaQuery = $"{_qry} WHERE num_venda = {vendaId}";

                return this.Query<VendaItemDominio>(_novaQuery).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public int Add(VendaItemDominio obj)
        {
            try
            {
                var _VendaItemId = this.ListaTodos(obj.VendaId).Count() + 1;

                var _query = @$" INSERT INTO venda_item (num_venda, num_venda_item, num_produto, qte_produto, val_preco_unitario, val_desconto_unitario, idc_situacao)
								 VALUES ({obj.VendaId}, {_VendaItemId}, {obj.ProdutoId}, {obj.QteProduto}, @ValPrecoUnitario, @ValDescontoUnitario, '{obj.IdcSituacao}')";

                Execute(_query, new { ValPrecoUnitario = obj.ValPrecoUnitario, ValDescontoUnitario = obj.ValDescontoUnitario });

                return _VendaItemId;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void CancelaItem(int VendaId, int vendaItemId)
        {
            try
            {
                var _query = @$" UPDATE venda_item 
                                 SET idc_situacao = 'I'
								 WHERE num_venda = {VendaId}
                                 AND   num_venda_item = {vendaItemId}";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

    }
}
