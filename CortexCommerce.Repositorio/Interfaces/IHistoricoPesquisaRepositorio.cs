using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Interfaces
{
    public interface IHistoricoPesquisaRepositorio
    {
        Task<int> AdicionarInteracaoAsync(HistoricoPesquisa historico);
        Task<IEnumerable<HistoricoPesquisa>> HistoricoDeUsuarioAsync(int usuarioId);
    }
}