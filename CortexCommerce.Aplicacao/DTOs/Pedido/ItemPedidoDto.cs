using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Aplicacao.DTOs
{
    public class ItemPedidoDto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalItem { get; set; }
    }
}