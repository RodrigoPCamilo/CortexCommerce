using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Contexto;
using CortexCommerce.Repositorio.Intefaces;

namespace CortexCommerce.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public UsuarioRepositorio(CortexCommerceContexto contexto) : base(contexto)
        {
        }
        public void Criar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            SalvarAlteracoes();
        }
        public void Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            SalvarAlteracoes();
        }

        public IEnumerable<Usuario> Listar()
        {
            return _contexto.Usuarios.ToList();
        }

        public Usuario ObterPorEmail(string email)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario ObterPorId(int id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}