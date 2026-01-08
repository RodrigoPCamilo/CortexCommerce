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

        public void Criar(Pedido pedido)
        {
            _contexto.pedidos.Add(pedido);
            SalvarAlteracoes();
        }
        public void Atualizar(Pedido pedido)
        {
            _contexto.pedidos.Update(pedido);
            SalvarAlteracoes();
        }

        public IEnumerable<Pedido> ListarPorUsuario(int usuarioId)
        {
            return _contexto.pedidos.Include(p => p.Items).Where(p => p.UsuarioId == usuarioId).ToList();
        }

        public Pedido ObterPedidoAbertoPorUsuario(int usuarioId)
        {
            return _contexto.pedidos.Include(p => p.Items).FirstOrDefault(p => p.UsuarioId == usuarioId && p.Status != StatusPedido.Finalizado && p.Status != StatusPedido.Cancelado);
        }

        public Pedido ObterPorId(int id)
        {
            return _contexto.pedidos.Include(p => p.Items).FirstOrDefault(p => p.Id == id);
        }
    }
}