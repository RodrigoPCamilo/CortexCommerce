using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Aplicacao.DTOs
{
    public class CriarPedidoDto
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}