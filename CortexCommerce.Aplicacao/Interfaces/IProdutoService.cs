using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IProdutoService
    {
        void Criar(CriarProdutoDto dto);
        IEnumerable<ProdutoDto> ListarDisponiveis();
    }
}