using Domain.Contracts;
using Domain.Model.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Autenticador.Api.Controllers
{
    [ApiController]
    [Route("autenticador/[controller]")]
    public class SenhaController : Controller
    {
        private readonly IValidarSenhaServices _services;
        public SenhaController(IValidarSenhaServices validarSenhaServices)
        {
            _services = validarSenhaServices;
        }

        /// <summary>
        /// Verifica se a senha fornecida está dentro dos criterios necessarios.
        /// </summary>
        /// <param name="senha"></param>
        /// <returns>string</returns>
        [HttpGet]
        [Route("validar")]
        public IActionResult Validar(string senha)
        {
            if (_services.Validar(senha)) return Ok(new ValidarSenha() { Mensagem = "Senha valida" });
            return BadRequest(new ValidarSenha() { Mensagem = "Senha invalida" });
        }
    }
}
