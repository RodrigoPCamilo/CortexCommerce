using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Aplicacao.DTOs
{
    public class CriarProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}