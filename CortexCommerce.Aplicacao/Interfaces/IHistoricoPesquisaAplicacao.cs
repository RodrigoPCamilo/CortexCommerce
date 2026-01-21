using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Historico;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IHistoricoPesquisaAplicacao
    {
        Task<int> PerguntarAsync(HistoricoPesquisa historicoPesquisa);
        Task<IEnumerable<HistoricoPesquisa>> ListarAsync(int usuarioId);
    }
}