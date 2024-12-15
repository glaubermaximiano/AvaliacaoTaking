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

            servico.AddScoped<IFilialAppServico, FilialAppServico>();
            servico.AddScoped<IFilialServico, FilialServico>();
            servico.AddScoped<IFilialRepositorio>(s => new FilialRepositorio(string.Empty));

            servico.AddScoped<IProdutoAppServico, ProdutoAppServico>();
            servico.AddScoped<IProdutoServico, ProdutoServico>();
            servico.AddScoped<IProdutoRepositorio>(s => new ProdutoRepositorio(string.Empty));

            servico.AddScoped<IVendaAppServico, VendaAppServico>();
            servico.AddScoped<IVendaServico, VendaServico>();
            servico.AddScoped<IVendaRepositorio>(s => new VendaRepositorio(string.Empty));

            servico.AddScoped<IVendaItemAppServico, VendaItemAppServico>();
            servico.AddScoped<IVendaItemServico, VendaItemServico>();
            servico.AddScoped<IVendaItemRepositorio>(s => new VendaItemRepositorio(string.Empty));
        }
    }
}
