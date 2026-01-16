using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Repositorio.Contexto;

namespace CortexCommerce.Repositorio
{
    public class BaseRepositorio
    {
        protected readonly CortexCommerceContexto _contexto;

        protected BaseRepositorio(CortexCommerceContexto contexto)
        {
            _contexto = contexto;
        }

    }
}