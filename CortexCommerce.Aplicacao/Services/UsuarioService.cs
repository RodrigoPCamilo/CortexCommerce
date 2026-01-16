using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Aplicacao.Interfaces;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio;
using CortexCommerce.Repositorio.Intefaces;


namespace CortexCommerce.Aplicacao.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Atualizar(AtualizarUsuarioDto dto)
        {
            var usuario = await _repositorio.ObterPorId(dto.Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            usuario.AtualizarPerfil(
                dto.Nome,
                dto.CategoriaFavorita,
                dto.OrcamentoMedio
            );

          await  _repositorio.Atualizar(usuario);
        }

        public async Task Criar(CriarUsuarioDto dto)
        {
            var usuario = new Usuario(
                dto.Nome,
                dto.Email,
                dto.Senha,
                dto.CategoriaFavorita,
                dto.OrcamentoMedio
            );
          await  _repositorio.Criar(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> Listar()
        {
            var Usuario = await _repositorio.Listar();
            return Usuario
            .Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                CategoriaFavorita = u.CategoriaFavorita,
                OrcamentoMedio = u.OrcamentoMedio
            });
        }

        public async Task<UsuarioDto> ObterPorId(int id)
        {
            var usuario = await _repositorio.ObterPorId(id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CategoriaFavorita = usuario.CategoriaFavorita,
                OrcamentoMedio = usuario.OrcamentoMedio
            };
        }
    }
}