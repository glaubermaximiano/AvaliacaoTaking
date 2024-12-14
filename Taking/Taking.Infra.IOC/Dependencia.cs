using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Interface;
using Taking.Aplicacao.Servico;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Interface.Servico;
using Taking.Dominio.Servico;
using Taking.Infra.Dados;
using Taking.Infra.Dados.Repositorio;

namespace Taking.Infra.IOC
{
    public static class Dependencia
    {
        [ExcludeFromCodeCoverage]
        public static void RegistrarDependencias(IServiceCollection servico)
        {
            servico.AddSingleton<IUnitOfWork, UnitOfWork>();

            servico.AddScoped<IClienteAppServico, ClienteAppServico>();
            servico.AddScoped<IClienteServico, ClienteServico>();
            servico.AddScoped<IClienteRepositorio>(s => new ClienteRepositorio(string.Empty));
        }
    }
}
