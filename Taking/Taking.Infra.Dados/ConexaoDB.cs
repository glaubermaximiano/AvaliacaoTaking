using Dapper;
using Npgsql;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Taking.Infra.Dados
{
    [ExcludeFromCodeCoverage]
    public abstract class ConexaoDB
    {
        readonly string _strConexao;

        protected ConexaoDB(string strConexao)
            => _strConexao = strConexao;

        IDbConnection ConexaoBD
        {
            get
            {
                var _conexao = new NpgsqlConnection(_strConexao);
                _conexao.Open();

                var _idcConectando = _conexao.State == ConnectionState.Connecting;

                while (_idcConectando)
                {
                    Thread.Sleep(1000);

                    _idcConectando = _conexao.State == ConnectionState.Connecting;
                }

                return _conexao;
            }
        }

        protected int Execute(string sql, string nomColunaId)
        {
            using (var con = new NpgsqlConnection(_strConexao))
            {
                con.Open();

                try
                {
                    using (var cmd = new NpgsqlCommand($"{sql} RETURNING {nomColunaId}", con))
                    {
                        return int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected object Execute(string sql)
        {
            using (var con = new NpgsqlConnection(_strConexao))
            {
                con.Open();

                try
                {
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void Execute(string sql, object param = null)
        {
            using (var con = this.ConexaoBD)
            {
                try
                {
                    con.Execute(sql, param);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (var con = this.ConexaoBD)
            {
                try
                {
                    return con.Query<T>(sql, param);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected T QueryFirstOrDefault<T>(string sql, object param = null)
        {
            using (var con = this.ConexaoBD)
            {
                try
                {
                    return con.QueryFirstOrDefault<T>(sql, param);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
