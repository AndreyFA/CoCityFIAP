using CoCity.WebAPI.Models;
using CoCity.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoCity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamacoesController : ControllerBase
    {
        private readonly CoCityContexto _contexto;

        public ReclamacoesController(CoCityContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovaReclamacao(ReclamacaoModel reclamacao)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _contexto.Reclamacoes.AddAsync(reclamacao);
                await _contexto.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReclamacaoModel>> ObterReclamacaoPorId(int id)
        {
            try
            {
                return Ok(await _contexto.Reclamacoes.FindAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}