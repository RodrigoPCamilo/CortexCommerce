using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Usuario;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IUsuarioService
    {
        void Criar(CriarUsuarioDto dto);
        void Atualizar(AtualizarUsuarioDto dto);
        UsuarioDto ObterPorId(int id);
        IEnumerable<UsuarioDto> Listar();
    }
}