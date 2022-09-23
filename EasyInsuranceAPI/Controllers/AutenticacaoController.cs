using CrossCutting.Utils;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Net.Mime;

namespace EasyInsuranceAPI.Controllers
{
    [Route("api/v1/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Utilizado para criar novos usuários
        /// </summary>
        /// <param name="criarUsuarioModel">Dados do usuário</param>
        /// <response code="200">Registro realizado com sucesso</response>
        /// <response code="400">E-mail já utilizado</response>
        /// <response code="404">Perfil de usuário acesso inválido</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPost("registro")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDadosBase<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult RegistrarUsuario([FromBody] CriarUsuarioModel criarUsuarioModel)
        {
            try
            {
                _usuarioService.CriarUsuario(criarUsuarioModel);
                return Ok(new ResponseBase(ResponseStatus.Sucesso, Mensagens.SucessoRegistrarUsuario));
            }
            catch (PerfilNaoExisteException e)
            {
                return NotFound(new ResponseBase(ResponseStatus.Falha, e.Message));
            }
            catch (EmailUtilizadoException e)
            {
                return BadRequest(new ResponseBase(ResponseStatus.Falha, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDadosBase<string>(ResponseStatus.Erro, Mensagens.ErroRegistrarUsuario, e.Message));
            }
        }

        /// <summary>
        /// Utilizado para realizar login no sistema
        /// </summary>
        /// <param name="loginModel">Dados utilizados no login</param>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="400">Email ou senha inválidos</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPost("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseBase), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseDadosBase<string>), StatusCodes.Status500InternalServerError)]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var response = _usuarioService.Login(loginModel);
                return Ok(new ResponseDadosBase<TokenUsuarioResponse>(ResponseStatus.Sucesso, Mensagens.SucessoLogin, response));
            }
            catch (EmailSenhaInvalidoException e)
            {
                return BadRequest(new ResponseBase(ResponseStatus.Falha, e.Message));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDadosBase<string>(ResponseStatus.Erro, Mensagens.ErroLogin, e.Message));
            }
        }
    }
}
