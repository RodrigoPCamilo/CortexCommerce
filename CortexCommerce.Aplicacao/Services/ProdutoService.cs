using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Intefaces;

namespace CortexCommerce.Aplicacao.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _repositorio;
        public ProdutoService(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task Criar(CriarProdutoDto dto)
        {
            var produto = new Produto(
                dto.Nome,
                dto.Descricao,
                dto.Categoria,
                dto.Preco,
                dto.Estoque
            );
          await  _repositorio.Criar(produto);
        }

       public async Task<IEnumerable<ProdutoDto>> ListarDisponiveis()
{
    var produtos = await _repositorio.Listar();

    return produtos
        .Where(p => p.Estoque > 0)
        .Select(p => new ProdutoDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Categoria = p.Categoria,
            Preco = p.Preco,
            Estoque = p.Estoque
        });
}

    }
}