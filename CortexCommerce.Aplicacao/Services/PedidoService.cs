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

        public void AdicionarItem(int pedidoId, int ProdutoId, int quantidade)
        {
            var pedido = _pedidoRepositorio.ObterPedidoAberto(usuarioId: pedidoId);

            if (pedido == null)

                throw new Exception("Pedido aberto não encontrado para o usuário.");

            var produto = _produtoRepositorio.ObterPorId(ProdutoId);

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

        public int CriarPedido(CriarPedidoDto dto)
        {
            var pedido = _pedidoRepositorio.ObterPedidoAberto(dto.UsuarioId);
            if (pedido == null)
            {
                pedido = new Pedido(dto.UsuarioId);
                _pedidoRepositorio.Criar(pedido);
            }
            return pedido.Id;
        }

        public void FinalizarPedido(int usuarioId)
        {
            var pedido = _pedidoRepositorio.ObterPedidoAberto(usuarioId);
            if (pedido == null)
                throw new Exception("Pedido aberto não encontrado para o usuário.");
            pedido.Finalizar();
        }

        public PedidoDto ObterPedidoAberto(int usuarioId)
        {
            var pedido = _pedidoRepositorio.ObterPedidoAberto(usuarioId);
            if (pedido == null)
                return null;
            return MapearParaDto(pedido);
        }
        private PedidoDto MapearParaDto(Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                Status = pedido.Status,
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