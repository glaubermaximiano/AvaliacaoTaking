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
            Init();
            _appServico = appServico;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult ListaTodos(string idcSituacao)
           => Get(_appServico.ListaTodos(idcSituacao));

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial/{Id}")]
        public IActionResult BuscaPorId(int Id)
           => Get(_appServico.BuscaPorId(Id));

        [HttpPost]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult Add([FromBody] FilialDominio obj)
           => Add(_appServico, obj);

        [HttpPut]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial")]
        public IActionResult Update([FromBody] FilialDominio obj)
           => Update(_appServico, obj);

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial/{Id}")]
        public IActionResult Remove(int Id)
          => Remove(_appServico, Id);

        [HttpPatch]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/filial/{Id}/cancela")]
        public IActionResult Cancela(int Id)
           => Cancela(_appServico, Id);
    }
}
