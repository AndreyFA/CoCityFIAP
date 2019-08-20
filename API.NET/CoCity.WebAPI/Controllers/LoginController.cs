using CoCity.WebAPI.Models;
using CoCity.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CoCity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly CoCityContexto _contexto;

        public LoginController(CoCityContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<ActionResult> AutenticarUsuario(AutenticacaoModel autenticacao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Unauthorized();

                var credenciaisValidas =
                    await _contexto.Usuarios.AnyAsync(c => c.Email == autenticacao.Email && c.Senha == autenticacao.Senha);

                if (!credenciaisValidas)
                    return Unauthorized("Email/Senha inválidos.");


                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}