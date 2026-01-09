using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Enums;

namespace CortexCommerce.Aplicacao.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public StatusPedido Status { get; set; }
        public decimal Total { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new();
    }
}