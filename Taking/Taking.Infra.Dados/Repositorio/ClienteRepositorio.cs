﻿using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Taking.Dominio.Entidade;
using Taking.Dominio.Helper;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.Infra.Dados.Repositorio
{
    [ExcludeFromCodeCoverage]
    public class ClienteRepositorio : ConexaoDB, IClienteRepositorio
    {
        public ClienteRepositorio(string strConexao)
            : base(strConexao) { }

        string _qry = @" SELECT num_cliente as Id,
                                nom_cliente as NomCliente,
                                cod_telefone as CodTelefone,
                                end_cliente as EndCliente,
                                idc_situacao as IdcSituacao
                         FROM cliente ";

        public List<ClienteDominio> ListaTodos(string idcSituacao)
        {
            try
            {
                var _filtro = string.Empty;

                if (idcSituacao != "T")
                {
                    _filtro = $" WHERE idc_situacao = '{idcSituacao}'";
                }

                return this.Query<ClienteDominio>($"{_qry} {_filtro}").ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + this.GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public ClienteDominio BuscaPorId(int id)
        {
            try
            {
                return QueryFirstOrDefault<ClienteDominio>($"{_qry} WHERE num_cliente = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Add(ClienteDominio obj)
        {
            try
            {
                var _query = @$" INSERT INTO cliente (nom_cliente, cod_telefone, end_cliente, idc_situacao)
								 VALUES ('{obj.NomCliente.Trim()}', '{UtilHelper.SomenteNumero(obj.CodTelefone.Trim().PadLeft(11, '0'))}', '{obj.EndCliente.Trim()}', '{obj.IdcSituacao.Trim()}')";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Update(ClienteDominio obj)
        {
            try
            {
                var _query = @$" UPDATE cliente 
                                 SET nom_cliente = '{obj.NomCliente.Trim()}', 
                                     cod_telefone = '{UtilHelper.SomenteNumero(obj.CodTelefone.Trim().PadLeft(11, '0'))}',
                                     end_cliente = '{obj.EndCliente.Trim()}'
                                 WHERE num_cliente= {obj.Id} ";

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
                var _query = @$" DELETE FROM cliente 
                                 WHERE num_cliente= {id} ";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }

        public void Cancela(int id)
        {
            try
            {
                var _query = @$" UPDATE cliente 
                                 SET idc_situacao = 'I'
                                 WHERE num_cliente= {id} ";

                Execute(_query);
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO " + GetType().Name + "." + MethodBase.GetCurrentMethod() + "(): " + ex.Message);
            }
        }
    }
}
