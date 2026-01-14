using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.API.Models.Pedidos.Requisicao;
using CortexCommerce.API.Models.Pedidos.Resposta;
using CortexCommerce.Aplicacao.DTOs;
using CortexCommerce.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult Criar(CriarPedidoDto request)
        {
            // _pedidoService.CriarPedido(request.UsuarioId);
            return Ok();
        }
        [HttpPost("adicionar-item")]
        public IActionResult AdicionarItem(AdicionarItemRequest request)
        {
            _pedidoService.AdicionarItem(
                request.UsuarioId,
                request.ProdutoId,
                request.Quantidade
            );
            return Ok();
        }
        [HttpGet("UsuarioId")]
        public IActionResult ObterPedidoAberto(int usuarioId)
        {
            var pedido = _pedidoService.ObterPedidoAberto(usuarioId);
            if (pedido == null)
                return NotFound();

            return Ok(new PedidoResponse
            {
                // PedidoId = pedido.Id,
                // UsuarioId = pedido.UsuarioId,
                // Status = pedido.Status.ToString(),
                // Total = pedido.CalcularTotal()
                
            });
        }
    }
}