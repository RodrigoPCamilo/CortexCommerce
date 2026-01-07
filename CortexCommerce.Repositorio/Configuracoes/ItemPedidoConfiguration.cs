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
        }
    }
}