using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Repositorio.Intefaces
{
    public interface IUsuarioRepositorio
    {
        
        Task Criar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task<Usuario> ObterPorId(int id);
         Task<Usuario> ObterPorEmail(string email);
        Task<IEnumerable<Usuario>> Listar();
    }
}