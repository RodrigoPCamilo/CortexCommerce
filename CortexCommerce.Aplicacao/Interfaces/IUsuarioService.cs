using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Usuario;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        Task Criar(CriarUsuarioDto dto);
        Task Atualizar(AtualizarUsuarioDto dto);
        Task<UsuarioDto >ObterPorId(int id);
        Task<IEnumerable<UsuarioDto>> Listar();
        
    }
}