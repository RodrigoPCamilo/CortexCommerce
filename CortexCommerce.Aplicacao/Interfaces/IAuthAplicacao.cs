using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Aplicacao.DTOs.Login;

namespace CortexCommerce.Aplicacao.Interfaces
{
    public interface IAuthAplicacao
    {
       Task<AuthResponseDTO> LoginAsync(LoginDto dto);

    }
}