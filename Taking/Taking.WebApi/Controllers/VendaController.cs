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
        readonly IVendaAppServico _appServico;

        public VendaController(ConfigAmbiente config,
                                 IUnitOfWork unitOfWork,
                                 IVendaAppServico appServico)
            : base(config, unitOfWork)
        {
            _appServico = appServico;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/busca-por-data")]
        public IActionResult BuscaPorData(string dataInicio, string dataFim)
        {
            Init();
            return Get(_appServico.BuscaPorData(DateTime.Parse(dataInicio), DateTime.Parse(dataFim)));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/AvaliacaoTaking/venda/{CodVenda}")]
        public IActionResult BuscaPeloCodigo(string CodVenda)
        {
            Init();
            return Get(_appServico.BuscaPeloCodigo(CodVenda));
        }

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
    }
}
