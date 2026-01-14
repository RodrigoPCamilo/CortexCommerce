using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.API.Models.Usuarios.Requisicao;
using CortexCommerce.API.Models.Usuarios.Resposta;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Criar(CriarUsuarioRequest request)
        {
            var dto = new CriarUsuarioDto
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                CategoriaFavorita = request.CategoriaFavorita,
                OrcamentoMedio = request.OrcamentoMedio
            };

            _usuarioService.Criar(dto);

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarUsuarioRequest request)
        {
            var dto = new AtualizarUsuarioDto
            {
                Id = id,
                Nome = request.Nome,
                CategoriaFavorita = request.CategoriaFavorita,
                OrcamentoMedio = request.OrcamentoMedio
            };

            _usuarioService.Atualizar(dto);

            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var usuario = _usuarioService.ObterPorId(id);
            if (usuario == null)
                return NotFound();

            return Ok(new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CategoriaFavorita = usuario.CategoriaFavorita,
                OrcamentoMedio = usuario.OrcamentoMedio
            });
        }
    }
}