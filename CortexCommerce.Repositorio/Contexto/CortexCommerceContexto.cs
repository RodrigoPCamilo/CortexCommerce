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
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<ItemPedido> itemPedido { get; set; }
        public CortexCommerceContexto()
        {

        }
        public CortexCommerceContexto(DbContextOptions<CortexCommerceContexto> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=DESKTOP-CSIL4LB\\SQLEXPRESS;Database=CortexCommerceDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            
        }
    }
}