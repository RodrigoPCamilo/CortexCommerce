using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IUsuarioRepositorio
    {
        void Criar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario ObterPorId(int id);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> Listar();
    }
}