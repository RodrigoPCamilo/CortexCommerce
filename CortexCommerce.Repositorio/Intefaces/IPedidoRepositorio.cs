using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IPedidoRepositorio
    {
        void Criar(Pedido pedido);
        Pedido ObterPorId(int id);
        Pedido ObterPedidoAbertoPorUsuario(int usuarioId);
        IEnumerable<Pedido> ListarPorUsuario(int usuarioId);
        void Atualizar(Pedido pedido);
    }
}