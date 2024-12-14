using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Interface;
using Taking.Dominio.Config;
using Taking.Dominio.Entidade;
using Taking.Dominio.Interface.Repositorio;

namespace Taking.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class ClienteController : TakingWebApi<ClienteDominio>
    {
        readonly IClienteAppServico _appServico;

        public ClienteController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IClienteAppServico appServico)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/cliente")]
        public IActionResult ListaTodos(string idcSituacao)
        {
            Init();

            return Get(_appServico.ListaTodos(idcSituacao));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/cliente/{Id}")]
        public IActionResult BuscaPorId(int Id)
        {
            Init();

            return Get(_appServico.BuscaPorId(Id));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/cliente")]
        public IActionResult Add([FromBody] ClienteDominio obj)
        {
            return Add(_appServico, obj);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/cliente")]
        public IActionResult Update([FromBody] ClienteDominio obj)
        {
            return Update(_appServico, obj);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/cliente/{Id}")]
        public IActionResult Remove(int Id)
        {
            return Remove(_appServico, Id);
        }
    }
}
