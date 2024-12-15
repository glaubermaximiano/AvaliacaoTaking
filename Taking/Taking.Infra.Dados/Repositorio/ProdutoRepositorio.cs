using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Infra.Dados.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class ProdutoRepositorio : ConexaoDB, IProdutoRepositorio
    {
        public ProdutoRepositorio(string strConexao)
            : base(strConexao) { }

        string _qry = @" SELECT num_produto as Id,
                                cod_produto as CodProduto,
                                nom_produto as NomProduto,
                                desc_produto as DescProduto,
                                val_preco_unitario as ValPrecoUnitario,
                                idc_situacao as IdcSituacao
                         FROM produto ";

        public List<ProdutoDominio> ListaTodos(string idcSituacao)
        {
            try
            {
                var _filtro = string.Empty;

                if (idcSituacao != "T")
                {
                    _filtro = $" WHERE idc_situacao = '{idcSituacao}'";
                }

                return this.Query<ProdutoDominio>($"{_qry} {_filtro}").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public ProdutoDominio BuscaPorId(int id)
        {
            try
            {
                return QueryFirstOrDefault<ProdutoDominio>($"{_qry} WHERE num_produto = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public ProdutoDominio BuscaPeloCodigo(string codProduto)
        {
            try
            {
                return QueryFirstOrDefault<ProdutoDominio>($"{_qry} WHERE cod_produto = '{codProduto}'");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Add(ProdutoDominio obj)
        {
            try
            {
                var _query = @$" INSERT INTO produto (cod_produto, nom_produto, desc_produto, val_preco_unitario, idc_situacao)
								 VALUES ('{obj.CodProduto.Trim()}', '{obj.NomProduto.Trim()}', '{obj.DescProduto.Trim()}', @ValPrecoUnitario, '{obj.IdcSituacao.Trim()}')";

                Execute(_query, new { ValPrecoUnitario = obj.ValPrecoUnitario});
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Update(ProdutoDominio obj)
        {
            try
            {
                var _query = @$" UPDATE produto 
                                 SET nom_produto = '{obj.NomProduto.Trim()}', 
                                     desc_produto = '{obj.DescProduto.Trim()}', 
                                     val_preco_unitario = @ValPrecoUnitario, 
                                     idc_situacao = '{obj.IdcSituacao.Trim()}'
                                  WHERE num_produto = {obj.Id}";

                Execute(_query, new { ValPrecoUnitario = obj.ValPrecoUnitario });
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
                var _query = @$" DELETE FROM produto 
                                 WHERE num_produto = {id}";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

    }
}
