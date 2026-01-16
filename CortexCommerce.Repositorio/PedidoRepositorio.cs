using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Dominio.Enums;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CortexCommerce.Repositorio
{
    public class PedidoRepositorio : BaseRepositorio, IPedidoRepositorio
    {
        public PedidoRepositorio(CortexCommerceContexto contexto) : base(contexto)
        {
        }

        public async Task Criar(Pedido pedido)
        {
            _contexto.Pedidos.Add(pedido);
           await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(Pedido pedido)
        {
            _contexto.Pedidos.Update(pedido);
            await _contexto.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pedido>> ListarPorUsuario(int usuarioId)
        {
            return await _contexto.Pedidos.Include(p => p.Items).Where(p => p.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<Pedido> ObterPedidoAberto(int usuarioId)
        {
            return await _contexto.Pedidos.Include(p => p.Items).FirstOrDefaultAsync(p => p.UsuarioId == usuarioId && p.Status != StatusPedido.Finalizado && p.Status != StatusPedido.Cancelado);
        }

        public async Task<Pedido> ObterPorId(int id)
        {
            return await _contexto.Pedidos.Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}