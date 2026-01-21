using CortexCommerce.Aplicacao.DTOs.Historico;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Interfaces;


namespace CortexCommerce.Aplicacao.Aplicacao
{
    public class HistoricoPesquisaAplicacao : IHistoricoPesquisaAplicacao
    {
        private readonly IHistoricoPesquisaRepositorio _historicoPesquisaRepositorio;

        public HistoricoPesquisaAplicacao( IHistoricoPesquisaRepositorio historicoPesquisaRepositorio)
        {
            
            _historicoPesquisaRepositorio = historicoPesquisaRepositorio;
        }
        public async Task<int> PerguntarAsync(HistoricoPesquisa historicoPesquisa)
        {
            return await _historicoPesquisaRepositorio.AdicionarInteracaoAsync(historicoPesquisa);
            
        }

        public async Task<IEnumerable<HistoricoPesquisa>> ListarAsync(int usuarioId)
        {
            return await _historicoPesquisaRepositorio.HistoricoDeUsuarioAsync(usuarioId);           
        }
    }
}