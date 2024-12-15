using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Interface;
using Taking.Dominio;
using Taking.Dominio.Config;
using Taking.Dominio.Entidade;
using Taking.Dominio.Helper;
using Taking.Dominio.Interface.Repositorio;
using Taking.Dominio.Request;
using Taking.Dominio.Validacao;

namespace Taking.WebApi.Controllers
{
    [ExcludeFromCodeCoverage]
    public class VendaController: TakingWebApi<VendaRequest>
    {
        readonly IVendaItemAppServico _vendaItem;
        readonly IVendaAppServico _appServico;

        public VendaController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IVendaItemAppServico vendaItem,
                                 IVendaAppServico appServico)
            : base(config, unitOfWork)
        {
            Init();

            _vendaItem = vendaItem;
            _appServico = appServico;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/busca-por-data")]
        public IActionResult BuscaPorData(string dataInicio, string dataFim)
           => Get(_appServico.BuscaPorData(DateTime.Parse(dataInicio), DateTime.Parse(dataFim)));

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/{CodVenda}")]
        public IActionResult BuscaPeloCodigo(int CodVenda)
           => Get(_appServico.BuscaPeloCodigo(CodVenda));

        [HttpPost]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda")]
        public IActionResult Add([FromBody] VendaRequest obj)
        {
            Init();

            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                return this.StatusCode(StatusCodes.Status201Created, _appServico.Add(obj).ToString());
            }
            catch (TakingException ex)
            {
                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/{CodVenda}/cancela")]
        public IActionResult Cancela(int CodVenda)
           => Cancela(_appServico, CodVenda);

        [HttpPatch]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/{CodVenda}/cancela/{IdItemVenda}")]
        public IActionResult CancelaItem(int CodVenda, int IdItemVenda)
        {
            Init();

            try
            {
                var _msg = _vendaItem.CancelaItem(_appServico.BuscaPeloCodigo(CodVenda).Id, IdItemVenda);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
