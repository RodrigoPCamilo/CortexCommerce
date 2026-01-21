using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio;
using CortexCommerce.Repositorio.Interfaces;


namespace CortexCommerce.Aplicacao.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio repositorio)
        {
            _usuarioRepositorio = repositorio;
        }

        public async Task<UsuarioDto> CriarAsync(CriarUsuarioDto dto)
        {
            var usuario = new Usuario(
                dto.Nome,
                dto.Email,
                dto.Senha,
                dto.CategoriaFavorita,
                dto.OrcamentoMedio,
                dto.LojaPreferida
            );

            await _usuarioRepositorio.CriarAsync(usuario);

            return Mapear(usuario);
        }

        public async Task<UsuarioDto> AtualizarAsync(int id, AtualizarUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.AtualizarDados(dto.Nome, dto.Email);
            usuario.AtualizarPreferencias(
                dto.CategoriaFavorita,
                dto.OrcamentoMedio,
                dto.LojaPreferida
            );

            await _usuarioRepositorio.AtualizarAsync(usuario);

            return Mapear(usuario);
        }

        private static UsuarioDto Mapear(Usuario usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CategoriaFavorita = usuario.CategoriaFavorita,
                OrcamentoMedio = usuario.OrcamentoMedio
            };
        }
        public async Task<UsuarioDto> ObterPorIdAsync(int id)
{
    var usuario = await _usuarioRepositorio.ObterPorIdAsync(id);

    if (usuario == null)
        throw new Exception("Usuário não encontrado");

    return Mapear(usuario);
}

    }
}