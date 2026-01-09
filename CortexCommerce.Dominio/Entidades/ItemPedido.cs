using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Dominio.Entidades
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public int PedidoId { get; private set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; private set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        protected ItemPedido()
        {

        }
        public ItemPedido( int produtoId, int quantidade, decimal precoUnitario)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (precoUnitario < 0)
                throw new ArgumentException("O preço unitário não pode ser negativo.");
            ProdutoId = produtoId;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
        public decimal CalcularTotal()
        {
            return Quantidade * PrecoUnitario;
        }
    }
}