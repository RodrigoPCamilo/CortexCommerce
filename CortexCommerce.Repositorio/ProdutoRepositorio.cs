using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Intefaces;

namespace CortexCommerce.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
    {
        protected ProdutoRepositorio(CortexCommerceContexto contexto) : base(contexto)
        {
        }

        public void Criar(Produto produto)
        {
            _contexto.produtos.Add(produto);
            SalvarAlteracoes();
        }
        public void Atualizar(Produto produto)
        {
            _contexto.produtos.Update(produto);
            SalvarAlteracoes();
        }

        public IEnumerable<Produto> Listar()
        {
            return _contexto.produtos.ToList();
        }

        public Produto ObterPorId(int id)
        {
            return _contexto.produtos.FirstOrDefault(p => p.Id == id);
        }
    }
}