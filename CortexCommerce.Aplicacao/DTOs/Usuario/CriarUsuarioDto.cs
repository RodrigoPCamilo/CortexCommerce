using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Aplicacao.DTOs.Usuario
{
    public class CriarUsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CategoriaFavorita { get; set; }
        public decimal OrcamentoMedio { get; set; }
    }
}