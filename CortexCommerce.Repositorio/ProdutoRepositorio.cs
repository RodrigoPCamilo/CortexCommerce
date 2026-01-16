using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CortexCommerce.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
    {
        public ProdutoRepositorio(CortexCommerceContexto contexto) : base(contexto)
        {
        }

        public async Task Criar(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            await _contexto.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Produto>> Listar()
        {
            return await _contexto.Produtos.ToListAsync();
        }

        public async Task<Produto> ObterPorId(int id)
        {
            return await _contexto.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}