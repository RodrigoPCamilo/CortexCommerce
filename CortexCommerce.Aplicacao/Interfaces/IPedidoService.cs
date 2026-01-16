using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IPedidoService
    {
        Task<int> CriarPedido(CriarPedidoDto dto);
        Task AdicionarItem(int pedidoId, int ProdutoId, int quantidade);
        Task FinalizarPedido(int usuarioId);
        Task<PedidoDto> ObterPedidoAberto(int usuarioId);
    }
}