using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CortexCommerce.Repositorio.Configuracoes
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos").HasKey(p => p.Id);
            builder.Property(p => p.UsuarioId).HasColumnName("UsuarioId").IsRequired();
            builder.Property(p => p.Status).HasColumnName("Status").HasConversion<int>().IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("DataPedido").IsRequired();

            builder.HasMany(p => p.Items)
                   .WithOne(i => i.Pedido)
                   .HasForeignKey(p => p.Id);
                   
        }
    }
}