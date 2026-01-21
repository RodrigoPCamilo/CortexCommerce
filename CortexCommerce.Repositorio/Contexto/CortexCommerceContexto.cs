using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using CortexCommerce.Repositorio.Configuracoes;
using Microsoft.EntityFrameworkCore;

namespace CortexCommerce.Repositorio.Contexto
{
    public class CortexCommerceContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistoricoPesquisa> HistoricoPesquisas { get; set; }
        

        public CortexCommerceContexto(DbContextOptions<CortexCommerceContexto> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoPesquisaConfiguration()); 
        }
    }
}                                                                                       