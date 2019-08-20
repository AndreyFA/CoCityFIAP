using CoCity.WebAPI.Models;
using CoCity.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoCity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CoCityContexto _contexto;

        public UsuariosController(CoCityContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> ObterTodos()
        {
            try
            {
                return Ok(await _contexto.Usuarios.AsNoTracking().ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CriarNovoUsuario(UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _contexto.AddAsync(usuario);
                await _contexto.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}/reclamacoes")]
        public async Task<ActionResult<IEnumerable<ReclamacaoModel>>> ObterReclamacoesPorUsuario(int id)
        {
            try
            {
                return Ok(await _contexto.Reclamacoes.Where(c => c.UsuarioId == id)?.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}/endereco")]
        public async Task<ActionResult<EnderecoModel>> ObterEnderecoPorUsuario(int id)
        {
            try
            {
                var usuario = await _contexto.Usuarios.FindAsync(id);
                var endereco = await _contexto.Enderecos.FindAsync(usuario.EnderecoId);

                return Ok(endereco);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}/endereco")]
        public async Task<ActionResult> CadastrarEnderecoUsuario(int id, [FromBody] EnderecoModel endereco)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var usuario = await _contexto.Usuarios.FindAsync(id);

                if (Equals(usuario, null))
                    return NotFound();

                await _contexto.Enderecos.AddAsync(endereco);

                usuario.EnderecoId = endereco.Id;
                _contexto.Usuarios.Update(usuario);

                await _contexto.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}