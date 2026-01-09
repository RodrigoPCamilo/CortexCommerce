using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IPedidoService
    {
        int CriarPedido(CriarPedidoDto dto);
        void AdicionarItem(int pedidoId, int ProdutoId, int quantidade);
        void FinalizarPedido(int usuarioId);
        PedidoDto ObterPedidoAberto(int usuarioId);
    }
}