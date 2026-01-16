using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.API.Models.Produtos.Resposta;
using CortexCommerce.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarDisponiveis()
        {
            var produtos =  await _produtoService.ListarDisponiveis();

            var response = produtos.Select(p => new ProdutoResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Categoria = p.Categoria,
                Preco = p.Preco,
                Estoque = p.Estoque
            });
            return Ok(response);
        }
    }
}