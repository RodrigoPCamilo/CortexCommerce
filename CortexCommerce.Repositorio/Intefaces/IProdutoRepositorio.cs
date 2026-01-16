using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IProdutoRepositorio
    {
        Task Criar(Produto produto);
        Task Atualizar(Produto produto);
        Task<Produto> ObterPorId(int id);
        Task<IEnumerable<Produto>> Listar(); 
        
    }
}