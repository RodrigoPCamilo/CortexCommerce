using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CortexCommerce.API.Models.IA.Requisicao;
using CortexCommerce.Aplicacao.DTOs.Historico;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CortexCommerce.API.Controllers
{
    [ApiController]
    [Route("api/ia")]
    [Authorize]
    public class IaController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;
        private readonly IIAService _iaService;
        private readonly IHistoricoPesquisaAplicacao _historicoPesquisaAplicacao;

        public IaController(IUsuarioAplicacao usuarioAplicacao, IIAService iaService,IHistoricoPesquisaAplicacao historicoPesquisaAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
            _iaService = iaService;
            _historicoPesquisaAplicacao = historicoPesquisaAplicacao;
        }
        [HttpPost("perguntar/{usuarioId}")]
        public async Task<IActionResult> Perguntar(int usuarioId, [FromBody] PerguntaDto dto)
        {
            if (string.IsNullOrEmpty(dto.Pergunta))
                return BadRequest("A pergunta não pode ser vazia.");

            var usuario = await _usuarioAplicacao.ObterPorIdAsync(usuarioId);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            var pronpt = $@"
            Você é um especialista em e-commerce e comparação de preços.

            Usuário: {usuario.Nome}
            Categoria favorita: {usuario.CategoriaFavorita}
            Orçamento médio: R$ {usuario.OrcamentoMedio}

            Pergunta do usuário:
            {dto.Pergunta}

            Responda com sugestões claras, objetivas e com foco em custo-benefício.
            ";
            var respostaIa = await _iaService.GetAiResponseAsync(pronpt);

            var historico = new HistoricoPesquisa
            (
                usuario.Id,
                dto.Pergunta,
                respostaIa,
                DateTime.UtcNow
            );

            await _historicoPesquisaAplicacao.PerguntarAsync(historico);

            return Ok(new RespostaIaDto { Resposta = respostaIa });
        }

        [HttpGet("historico/{usuarioId}")]
        public async Task<IActionResult> Historico( int usuarioId)
        {
            if (usuarioId <= 0)
                return BadRequest("ID de usuário inválido.");

            var historico = await _historicoPesquisaAplicacao.ListarAsync(usuarioId);

            var retorno = historico.Select(h => new HistoricoPesquisaDto
            {
                Pergunta = h.Pergunta,
                RespostaGerada = h.RespostaGerada,
                Data = h.Data
            });
            
            return Ok(retorno);
        }
    }
}