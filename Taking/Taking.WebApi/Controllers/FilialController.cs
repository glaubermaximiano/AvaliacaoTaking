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
    public class FilialController : TakingWebApi<FilialDominio>
    {
        readonly IFilialAppServico _appServico;

        public FilialController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IFilialAppServico appServico)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult ListaTodos(string idcSituacao)
        {
            Init();

            return Get(_appServico.ListaTodos(idcSituacao));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial/{Id}")]
        public IActionResult BuscaPorId(int Id)
        {
            Init();

            return Get(_appServico.BuscaPorId(Id));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult Add([FromBody] FilialDominio obj)
        {
            return Add(_appServico, obj);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult Update([FromBody] FilialDominio obj)
        {
            return Update(_appServico, obj);
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial/{Id}")]
        public IActionResult Remove(int Id)
        {
            return Remove(_appServico, Id);
        }
    }
}
