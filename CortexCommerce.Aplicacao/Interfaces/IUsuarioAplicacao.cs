using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Usuario;
using CortexCommerce.Dominio.Entidades;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        Task<UsuarioDto> CriarAsync(CriarUsuarioDto dto);
        Task<UsuarioDto> AtualizarAsync(int id, AtualizarUsuarioDto dto);
        Task<UsuarioDto> ObterPorIdAsync(int id);
        
    

    }
}