using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CortexCommerce.API.Models.Usuarios.Requisicao;
using CortexCommerce.API.Models.Usuarios.Resposta;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioService;

        public UsuarioController(IUsuarioAplicacao usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioDto dto)
        {
            var usuario = await _usuarioService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var usuario = await _usuarioService.ObterPorIdAsync(id);
            return Ok(usuario);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarUsuarioDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var usuarioAtualizado = await _usuarioService.AtualizarAsync(
                int.Parse(userId),
                dto
            );

            return Ok(usuarioAtualizado);
        }
    }
}