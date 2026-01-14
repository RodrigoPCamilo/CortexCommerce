using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.API.Models.Pedidos.Resposta
{
    public class PedidoResponse
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public string Status { get; set; }
        public decimal Total  { get; set; }
    }
}