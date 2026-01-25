using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Enums;

namespace CortexCommerce.Aplicacao.DTOs.Usuario
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CategoriaFavorita { get; set; }
        public decimal OrcamentoMedio { get; set; }
        public LojaPreferida LojaPreferida { get; set; }
}

}