using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using CrossCutting.Utils;
using Domain.Exceptions;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;

namespace EasyInsuranceAPI.Controllers
{
    [Route("api/v1/cotacao")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ISeguroService _seguroService;
        private readonly IUsuarioService _usuarioService;

        public CotacaoController(ISeguroService seguroService, IUsuarioService usuarioService)
        {
            _seguroService = seguroService;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Processa uma simulação de seguro
        /// </summary>
        /// <param name="modelo">Dados do modelo</param>
        /// <returns></returns>
        [HttpPost("processamento")]
        [Authorize]
        public IActionResult ProcessarSeguro([FromBody] CriarItemModel modelo)
        {
            try
            {
                var response = _seguroService.ProcessarSeguro(modelo);
                return Ok(new ResponseDadosBase<CotacaoModel>(ResponseStatus.Sucesso, Mensagens.Ok, response));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDadosBase<string>(ResponseStatus.Erro, Mensagens.FalhaEsqueciSenha, e.Message));
            }
        }

        /// <summary>
        /// Salva a cotação do usuário
        /// </summary>
        /// <param name="modelo">Dados da cotação</param>
        /// <param name="usuarioId">Id do usuário</param>
        /// <returns></returns>
        [HttpPost("{usuarioId}")]
        [Authorize]
        public IActionResult SalvarCotacao([FromBody] CriarItemModel modelo, Guid usuarioId)
        {
            try
            {
                var usuarioExiste = _usuarioService.BuscarUsuario(usuarioId);
                if (usuarioExiste == null)
                {
                    return NotFound(new ResponseBase(ResponseStatus.Falha, Mensagens.FalhaBuscarUsuario));
                }

                _seguroService.CriarSeguro(modelo, usuarioExiste);
                return Ok(new ResponseBase(ResponseStatus.Sucesso, Mensagens.SucessoCriarCotacao));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDadosBase<string>(ResponseStatus.Erro, Mensagens.FalhaEsqueciSenha, e.Message));
            }
        }

        /// <summary>
        /// Busca as cotações do usuário
        /// </summary>
        /// <param name="usuarioId">Id do usuário</param>
        /// <param name="busca">Parâmetro de busca</param>
        /// <param name="pagina">Página da busca</param>
        /// <param name="quantidade">Quatidade de itens da busca</param>
        /// <returns></returns>
        [HttpGet("{usuarioId}")]
        [Authorize]
        public IActionResult BuscarCotacoes(Guid usuarioId, string? busca = "", int pagina = 0, int quantidade = 15)
        {
            try
            {
                var usuarioExiste = _usuarioService.BuscarUsuario(usuarioId);
                if (usuarioExiste == null)
                {
                    return NotFound(new ResponseBase(ResponseStatus.Falha, Mensagens.FalhaBuscarUsuario));
                }

                var cotacoes = _seguroService.BuscarSeguros(usuarioId, busca, pagina, quantidade);
                return Ok(new ResponseDadosBase<List<CotacaoModel>?>(ResponseStatus.Sucesso, Mensagens.Ok, cotacoes));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDadosBase<string>(ResponseStatus.Erro, Mensagens.FalhaEsqueciSenha, e.Message));
            }
        }
    }
}
