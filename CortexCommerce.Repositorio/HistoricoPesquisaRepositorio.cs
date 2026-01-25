using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CortexCommerce.Repositorio.Interfaces
{
   public class HistoricoPesquisaRepositorio 
        : BaseRepositorio, IHistoricoPesquisaRepositorio
    {
        public HistoricoPesquisaRepositorio(IDbConnection connection)
            : base(connection)
        {
        }

        public async Task<int> AdicionarInteracaoAsync(HistoricoPesquisa historico)
        {
           return await _connection.QuerySingleAsync<int>(
                "spRegistraHistoricoPesquisa",
                new
                {
                    UsuarioId = historico.UsuarioId,
                    Pergunta = historico.Pergunta,
                    RespostaGerada = historico.RespostaGerada
                },
                commandType: CommandType.StoredProcedure
            );

        }

        public async Task<IEnumerable<HistoricoPesquisa>> HistoricoDeUsuarioAsync(int usuarioId)
        {
            return await _connection.QueryAsync<HistoricoPesquisa>(
                "spListarHistoricoPorUsuario",
                new
                {
                    UsuarioId = usuarioId
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}