using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CortexCommerce.Repositorio.Configuracoes
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos").HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(500);
            builder.Property(p => p.Categoria).HasColumnName("Categoria").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco).HasColumnType("Decimal(18,2)").IsRequired();
            builder.Property(p => p.Estoque).HasColumnName("Estoque").IsRequired();
        }
    }
}