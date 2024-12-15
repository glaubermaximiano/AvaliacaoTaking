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
    public class ProdutoController : TakingWebApi<ProdutoDominio>
    {
        readonly IProdutoAppServico _appServico;

        public ProdutoController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IProdutoAppServico appServico)
            : base(config, unitOfWork)
        {
            Init();
            _appServico = appServico;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto")]
        public IActionResult ListaTodos(string idcSituacao)
           => Get(_appServico.ListaTodos(idcSituacao));

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto/{Id}")]
        public IActionResult BuscaPorId(int Id)
           => Get(_appServico.BuscaPorId(Id));

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto/busca-pelo-codigo/{CodProduto}")]
        public IActionResult BuscaPeloCodigo(string CodProduto)
           => Get(_appServico.BuscaPeloCodigo(CodProduto));

        [HttpPost]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto")]
        public IActionResult Add([FromBody] ProdutoDominio obj)
           => Add(_appServico, obj);

        [HttpPut]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto")]
        public IActionResult Update([FromBody] ProdutoDominio obj)
           => Update(_appServico, obj);

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto/{Id}")]
        public IActionResult Remove(int Id)
           => Remove(_appServico, Id);

        [HttpPatch]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/produto/{Id}/cancela")]
        public IActionResult Cancela(int Id)
           => Cancela(_appServico, Id);
    }
}
