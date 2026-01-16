using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CortexCommerce.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(CortexCommerceContexto contexto) : base(contexto)
        {
        }
        public async Task Criar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
           await _contexto.SaveChangesAsync();
        }
        public async Task Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
           await _contexto.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Usuario>> Listar()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}