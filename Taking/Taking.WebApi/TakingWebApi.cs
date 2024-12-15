using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Taking.Aplicacao.Interface.CRUD;
using Taking.Dominio.Config;
using Taking.Dominio.Interface.Repositorio;
using System.Linq;
using Taking.Dominio.Validacao;
using System.Net.Http;
using System.Net;
using System.Diagnostics.CodeAnalysis;
using Taking.Aplicacao.Interface;

namespace Taking.WebApi
{
    [ExcludeFromCodeCoverage]
    public class TakingWebApi<T> : ControllerBase where T : class
    {
        readonly ConfigAmbiente _config;
        readonly IUnitOfWork _unitOfWork;

        public TakingWebApi(ConfigAmbiente config,
                            IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        protected void Init()
        {
            _unitOfWork.StrConexao = this._config.StrConexao;
        }

        protected ActionResult Get(IList<T> lst)
        {
            try
            {
                if (lst.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, new List<T>());
                }

                return Ok(lst);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Get<T>(T obj) where T : class
        {
            try
            {
                if (obj == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Get<T>(List<T> obj) where T : class
        {
            try
            {
                if (obj.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Get(T obj)
        {
            try
            {
                if (obj == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Add<T>(IAppServiceAdd<T> servico, T obj) where T : class
        {
            Init();

            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                _msg = servico.Add(obj);

                return string.IsNullOrEmpty(_msg) ? this.StatusCode(StatusCodes.Status201Created, _msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Update<T>(IAppServiceUpdate<T> servico, T obj) where T : class
        {
            Init();

            try
            {
                var _msg = ValidaPreenchimento.Validar(obj);

                if (!string.IsNullOrEmpty(_msg))
                {
                    return this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
                }

                _msg = servico.Update(obj);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Remove(IAppServiceRemove servico, int Id)
        {
            Init();

            try
            {
                var _msg = servico.Remove(Id);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected ActionResult Cancela(ICancelaAppServico servico, int Id)
        {
            Init();

            try
            {
                var _msg = servico.Cancela(Id);

                return string.IsNullOrEmpty(_msg) ? Ok(_msg) : this.StatusCode(StatusCodes.Status422UnprocessableEntity, _msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
