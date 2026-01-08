using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CortexCommerce.Repositorio.Configuracoes
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItemPedido").HasKey(i => i.Id);
            builder.Property(i => i.PedidoId).HasColumnName("PedidoId").IsRequired();
            builder.Property(i => i.ProdutoId).HasColumnName("ProdutoId").IsRequired();
            builder.Property(i => i.Quantidade).HasColumnName("Quantidade").IsRequired();
            builder.Property(i => i.PrecoUnitario).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasOne(i => i.Pedido)
                   .WithMany(p => p.Items)
                   .HasForeignKey(i => i.PedidoId);

            builder.HasOne(i => i.Produto)
                   .WithMany(p => p.ItemsPedido)
                   .HasForeignKey(i => i.ProdutoId);
        }
    }
}