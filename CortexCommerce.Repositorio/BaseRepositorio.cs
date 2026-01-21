using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Repositorio.Contexto;

namespace CortexCommerce.Repositorio
{
    public class BaseRepositorio
    {
        protected readonly IDbConnection _connection;

        protected BaseRepositorio(IDbConnection connection)
        {
            _connection = connection;
        }

    }
}