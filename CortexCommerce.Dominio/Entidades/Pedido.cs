using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Enums;

namespace CortexCommerce.Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario{ get; set; }
        public StatusPedido Status { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public List<ItemPedido> Items { get; private set; } = new List<ItemPedido>();
        protected Pedido()
        {

        }
        public Pedido(int usuarioId)
        {
            UsuarioId = usuarioId;
            Status = StatusPedido.criado;
            DataCriacao = DateTime.UtcNow;
            Items = new List<ItemPedido>();
        }
        public void AdicionarItem(ItemPedido item)
        {
            Items.Add(item);
        }
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.CalcularTotal();
            return total;
        }
        public void Finalizar()
        {
            Status = StatusPedido.Finalizado;
        }
    }
}