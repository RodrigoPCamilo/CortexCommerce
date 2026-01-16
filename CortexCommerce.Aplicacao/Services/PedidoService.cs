using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Intefaces;

namespace CortexCommerce.Aplicacao.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public PedidoService(IPedidoRepositorio pedidoRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task AdicionarItem(int pedidoId, int ProdutoId, int quantidade)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoAberto(usuarioId: pedidoId);

            if (pedido == null)

                throw new Exception("Pedido aberto não encontrado para o usuário.");

            var produto = await _produtoRepositorio.ObterPorId(ProdutoId);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.BaixarEstoque(quantidade);

            var item = new ItemPedido(
                produto.Id,
                quantidade,
                produto.Preco
            );
            pedido.AdicionarItem(item);
        }

        public async Task<int> CriarPedido(CriarPedidoDto dto)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoAberto(dto.UsuarioId);
            if (pedido == null)
            {
                pedido = new Pedido(dto.UsuarioId);
               await _pedidoRepositorio.Criar(pedido);
            }
            return pedido.Id;
        }

        public async Task FinalizarPedido(int usuarioId)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoAberto(usuarioId);
            if (pedido == null)
                throw new Exception("Pedido aberto não encontrado para o usuário.");
              pedido.Finalizar();
        }

        public async Task<PedidoDto> ObterPedidoAberto(int usuarioId)
        {
            var pedido = await _pedidoRepositorio.ObterPedidoAberto(usuarioId);
            if (pedido == null)
                return null;
            return MapearParaDto(pedido);
        }
        private PedidoDto MapearParaDto(Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                UsuarioId = pedido.UsuarioId,
                Status = pedido.Status.ToString(),
                Total = pedido.CalcularTotal(),
                Itens = pedido.Items.Select(i => new ItemPedidoDto
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade,
                    PrecoUnitario = i.PrecoUnitario,
                    TotalItem = i.CalcularTotal()
                }).ToList()
            };
        }
    }
}