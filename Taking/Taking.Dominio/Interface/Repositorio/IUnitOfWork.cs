﻿
namespace Taking.Dominio.Interface.Repositorio
{
    public interface IUnitOfWork
    {
        string StrConexao { set; get; }

        IClienteRepositorio Cliente { get; }
    }
}