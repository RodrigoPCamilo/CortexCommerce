using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IProdutoRepositorio
    {
        void Criar(Produto produto);
        void Atualizar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> Listar(); 
    }
}