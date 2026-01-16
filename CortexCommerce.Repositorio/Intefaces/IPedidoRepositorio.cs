using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IPedidoRepositorio
    {
        Task Criar(Pedido pedido);
        Task<Pedido> ObterPorId(int id);
        Task <Pedido> ObterPedidoAberto(int usuarioId);
        Task< IEnumerable<Pedido>> ListarPorUsuario(int usuarioId);
        Task Atualizar(Pedido pedido);
    }
}