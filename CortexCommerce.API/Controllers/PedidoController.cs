
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
        public async Task<IActionResult> Criar([FromBody] CriarPedidoRequest request)
        {
            var pedidoId = await _pedidoService.CriarPedido(
                new CriarPedidoDto
                {
                    UsuarioId = request.UsuarioId
                }
            );

            return Ok(new { PedidoId = pedidoId });
        }

        [HttpPost("adicionar-item")]
        public async Task<IActionResult> AdicionarItem([FromBody] AdicionarItemRequest request)
        {
            await _pedidoService.AdicionarItem(
                request.UsuarioId,
                request.ProdutoId,
                request.Quantidade
            );

            return Ok();
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObterPedidoAberto(int usuarioId)
        {
            var pedido = await _pedidoService.ObterPedidoAberto(usuarioId);

            if (pedido == null)
                return NotFound();

            return Ok(new PedidoResponse
            {
                PedidoId = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                Status = pedido.Status,
                Total = pedido.Total
            });
        }
    }
}
