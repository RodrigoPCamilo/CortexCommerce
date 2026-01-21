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
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IDbConnection connection) : base(connection)
        {
        }

        public async Task CriarAsync(Usuario usuario)
        {
            await _connection.ExecuteAsync(
                "spUsuarioCriar",
                new
                {
                    usuario.Nome,
                    usuario.Email,
                    usuario.SenhaHash,
                    usuario.CategoriaFavorita,
                    usuario.OrcamentoMedio,
                    usuario.LojaPreferida

                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            await _connection.ExecuteAsync(
                "spUsuarioAtualizar",
                new
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email,
                    usuario.CategoriaFavorita,
                    usuario.OrcamentoMedio,
                    usuario.LojaPreferida
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(
                "spUsuarioObterPorId",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(
                "spUsuarioObterPorEmail",
                new { Email = email },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<Usuario?> ObterPorIdComHistoricoAsync(int id)
        {
            using var multi = await _connection.QueryMultipleAsync(
                "spUsuarioObterComHistorico",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );

            var usuario = await multi.ReadFirstOrDefaultAsync<Usuario>();
            if (usuario == null) return null;

            usuario.HistoricoPesquisa = (await multi.ReadAsync<HistoricoPesquisa>()).ToList();
            return usuario;
        }
    }
}